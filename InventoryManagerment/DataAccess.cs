using InventoryManagerment.Models.EF;
using InventoryManagerment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Collections;
using InventoryManagerment.Common;
using InventoryManagerment.Models.WINFORMS;
using InventoryManagerment.ViewModel;

namespace InventoryManagerment
{
    public class DataAccess
    {
        InventoryDbContext db;
        //Khởi tạo
        public DataAccess()
        {
            db = new InventoryDbContext();
        }
        //Kiểm tra đăng nhập
        public int CheckUser(LoginModel model)
        {
            var user = db.Users.Where(x => x.UserName == model.UserName).SingleOrDefault();
            if (user == null)
            {
                return -1;
            }
            else
            {
                if (user.Password == model.Password)
                {
                    if (user.Status == true)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        public List<Customer> ListtAllCustomerToViewBag()
        {
            return db.Customers.ToList();
        }
        public List<Supplier> ListAllSupplierToViewBag()
        {
            return db.Suppliers.OrderBy(x => x.ID).ToList();
        }
        string GetStatus(bool status)
        {
            if (status == true)
            {
                return "Đã duyệt";
            }
            else
            {
                return "Chưa duyệt";
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng user
        public User GetUser(string userName = "", long? id = -1)
        {
            if (userName != "")
            {
                return db.Users.Where(x => x.UserName == userName).SingleOrDefault();
            }
            else
            {
                return db.Users.Find(id);
            }
        }
        public User GetUserByID(long id)
        {
            return db.Users.Find(id);
        }
        public IEnumerable<User> ListAllUserOnPagedlist(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<User> ListAllUserToViewBag()
        {
            return db.Users.ToList();
        }
        public bool UpdateUser(User model, string userName)
        {
            string action = "";
            try
            {
                var user = db.Users.Find(model.ID);
                if (user.UserName != model.UserName)
                {
                    user.UserName = model.UserName;
                    action += $" | Cập nhật tài khoản từ '{user.UserName}' thành '{model.UserName}'";
                }
                if (user.Password != model.Password)
                {
                    user.Password = model.Password;
                    action += $" | Cập nhật mật khẩu từ '{user.Password}' thành '{model.Password}'";
                }
                if (user.Name != model.Name)
                {
                    user.Name = model.Name;
                    action += $" | Cập nhật tên người dùng từ '{user.Name}' thành '{model.Name}'";
                }
                if (user.RoleID != model.RoleID)
                {
                    user.RoleID = model.RoleID;
                    action += $" | Cập nhật chức vụ từ '{user.RoleID}' thành '{model.RoleID}'";
                }
                if (user.Status != model.Status)
                {
                    user.Status = model.Status;
                    action += $" | Cập nhật trạng thái từ '{user.Status}' thành '{model.Status}'";
                }
                db.SaveChanges();
                SetHistory("update", userName, "người dùng ", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUser(long id, string userName)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                SetHistory("delete", userName, "người dùng ", $" | Xóa tên '{user.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertUser(User model, string userName)
        {
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                SetHistory("insert", userName, "người dùng ", $"| Thêm tên tài khoản '{model.UserName}'");
                return true;
            }
            catch { return false; }

        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng sản phẩm
        public IEnumerable<Product> ListAllProductOnPagedlist(string searchString,long quantity, long typeProduct, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if(quantity == 0)
            {
                if (!string.IsNullOrEmpty(searchString) && typeProduct == 0)
                {
                    model = model.Where(x => x.Name.Contains(searchString));
                }
                else if (!string.IsNullOrEmpty(searchString) && typeProduct != 0)
                {
                    model = model.Where(x => x.Name.Contains(searchString) && x.CategoryID.Value == typeProduct);
                }
                else if (string.IsNullOrEmpty(searchString) && typeProduct != 0)
                {
                    model = model.Where(x => x.CategoryID.Value == typeProduct);
                }
                else
                {
                    model = model.Where(x => x.ID != 0);
                }
            }
            else if(quantity == 1)
            {
                if (!string.IsNullOrEmpty(searchString) && typeProduct == 0)
                {
                    model = model.Where(x => x.Name.Contains(searchString) && x.Quantity < x.QuantityAlert && x.Quantity>0);
                }
                else if (!string.IsNullOrEmpty(searchString) && typeProduct != 0)
                {
                    model = model.Where(x => x.Name.Contains(searchString) && x.CategoryID.Value == typeProduct && x.Quantity < x.QuantityAlert && x.Quantity > 0);
                }
                else if (string.IsNullOrEmpty(searchString) && typeProduct != 0)
                {
                    model = model.Where(x => x.CategoryID.Value == typeProduct && x.Quantity < x.QuantityAlert && x.Quantity > 0);
                }
                else
                {
                    model = model.Where(x => x.ID != 0 && x.Quantity < x.QuantityAlert && x.Quantity > 0);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(searchString) && typeProduct == 0)
                {
                    model = model.Where(x => x.Name.Contains(searchString) && x.Quantity==0);
                }
                else if (!string.IsNullOrEmpty(searchString) && typeProduct != 0)
                {
                    model = model.Where(x => x.Name.Contains(searchString) && x.CategoryID.Value == typeProduct && x.Quantity==0);
                }
                else if (string.IsNullOrEmpty(searchString) && typeProduct != 0)
                {
                    model = model.Where(x => x.CategoryID.Value == typeProduct && x.Quantity==0);
                }
                else
                {
                    model = model.Where(x => x.ID != 0 && x.Quantity==0);
                }
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<Product> ListAllProduct()
        {
            return db.Products.ToList();
        }
        public List<Product> ListAllProductToViewBag()
        {
            return db.Products.OrderBy(x => x.ID).ToList();
        }
        public Product GetProduct(long id)
        {
            return db.Products.Find(id);
        }
        public bool UpdateProduct(Product model, string userName)
        {
            string action = "";
            try
            {
                var product = db.Products.Find(model.ID);
                if (product.Name != model.Name)
                {
                    product.Name = model.Name;
                    action += $"| Cập nhật tên từ {product.Name} thành '{model.Name}'";
                }
                if (product.Price != model.Price)
                {
                    product.Price = model.Price;
                    action += $"| Cập nhật giá nhập từ {product.Price} thành '{model.Price}'";
                }
                if (product.UnitID != model.UnitID)
                {
                    product.UnitID = model.UnitID;
                    action += $"| Cập nhật đơn vị tính từ {GetUnit(product.UnitID).Name} thành '{GetUnit(model.UnitID).Name}'";
                }
                if (product.QuantityAlert != model.QuantityAlert)
                {
                    product.QuantityAlert = model.QuantityAlert;
                    action += $"| Cập nhật số lượng tối thiểu từ {product.QuantityAlert} thành '{model.QuantityAlert}'";
                }
                if (product.CategoryID != model.CategoryID)
                {
                    product.CategoryID = model.CategoryID;
                    action += $"| Cập nhật tên danh mục từ {GetProductCategory(product.CategoryID).Name} thành '{GetProductCategory(model.CategoryID)}'";
                }
                db.SaveChanges();
                SetHistory("update", userName, "sản phẩm", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertProduct(Product model, string userName)
        {
            try
            {
                var result = db.Products.Add(model);
                db.SaveChanges();
                SetHistory("insert", userName, "danh mục sản phẩm ", $"| Thêm tên sản phẩm '{model.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProduct(long? id, string userName)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                SetHistory("delete", userName, "Danh mục sản phẩm", $" | Xóa tên '{product.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng danh mục sản phẩm
        public IEnumerable<ProductCategory> ListAllProductCategoryOnPagedlist(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<ProductCategory> ListAllCategoryToViewBag()
        {
            return db.ProductCategories.ToList();
        }
        public ProductCategory GetProductCategory(long? id)
        {
            return db.ProductCategories.Find(id);
        }
        public bool UpdateProductCategory(ProductCategory model, string userName)
        {
            try
            {
                string action = "";
                var category = db.ProductCategories.Find(model.ID);
                if (category.Name != model.Name)
                {
                    action += $"| Cập nhật tên danh mục từ '{category.Name}' thành '{model.Name}'";
                    category.Name = model.Name;
                }
                db.SaveChanges();
                SetHistory("update", userName, "danh mục sản phẩm ", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertProductCategory(ProductCategory model, string userName)
        {
            try
            {
                db.ProductCategories.Add(model);
                db.SaveChanges();
                SetHistory("insert", userName, "danh mục sản phẩm ", $"| Thêm tên danh mục sản phẩm '{model.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProductCategory(long? id, string userName)
        {
            try
            {
                var productcategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productcategory);
                db.SaveChanges();
                SetHistory("delete", userName, "Danh mục sản phẩm", $" | Xóa tên danh mục '{productcategory.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng đơn vị tính 
        public IEnumerable<Unit> ListAllUnitOnPagedlist(string searchString, int page, int pageSize)
        {
            IQueryable<Unit> model = db.Units;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<Unit> ListAllUnitToViewBag()
        {
            return db.Units.ToList();
        }
        public Unit GetUnit(long id)
        {
            return db.Units.Find(id);
        }
        public bool UpdateUnit(Unit model, string userName)
        {
            try
            {
                string action = "";
                var obj = db.Units.Find(model.ID);
                if (obj.Name != model.Name)
                {
                    action += $"| Cập nhật đơn vị tính từ '{obj.Name}' thành '{model.Name}'";
                    obj.Name = model.Name;
                }
                db.SaveChanges();
                SetHistory("update", userName, "đơn vị tính ", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertUnit(Unit model, string userName)
        {
            try
            {
                db.Units.Add(model);
                db.SaveChanges();
                SetHistory("insert", userName, "đơn vị tính ", $"| Thêm đơn vị tính '{model.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUnit(long? id, string userName)
        {
            try
            {
                var obj = db.Units.Find(id);
                db.Units.Remove(obj);
                db.SaveChanges();
                SetHistory("delete", userName, "đơn vị tính", $" | Xóa đơn vị tính '{obj.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng chức vụ
        public List<Role> ListAllRoleToViewBag()
        {
            return db.Roles.OrderBy(x => x.ID).ToList();
        }
        public IEnumerable<Role> ListAllRoleOnPagedlist(string searchString, int page, int pageSize)
        {
            IQueryable<Role> model = db.Roles;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public Role GetRole(long id)
        {
            return db.Roles.Find(id);
        }
        public bool UpdateRole(Role model, string userName)
        {
            try
            {
                string action = "";
                var obj = db.Roles.Find(model.ID);
                if (obj.Name != model.Name)
                {
                    action += $"| Cập nhật chức vụ từ '{obj.Name}' thành '{model.Name}'";
                    obj.Name = model.Name;
                }
                db.SaveChanges();
                SetHistory("update", userName, "chức vụ ", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertRole(Role model, string userName)
        {
            try
            {
                db.Roles.Add(model);
                db.SaveChanges();
                SetHistory("insert", userName, "chức vuj ", $"| Thêm chức vụ '{model.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteRole(long? id, string userName)
        {
            try
            {
                var obj = db.Roles.Find(id);
                db.Roles.Remove(obj);
                db.SaveChanges();
                SetHistory("delete", userName, "chức vụ", $" | Xóa đơn vị tính '{obj.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng nhà cung cấp
        public bool CheckSupplier(Supplier model)
        {
            var result = db.Suppliers.Where(x => x.Name == model.Name).ToList();
            if (result.Count == 0) { return true; } else { return false; }
        }
        public IEnumerable<SupplierViewModel> ListAllSupplierOnPagedList(string searchString, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var result = from supplier in db.Suppliers
                             join supply in db.SupplyDetails on supplier.ID equals supply.SupplierID
                             join product in db.Products on supply.ProductCode equals product.Code
                             where supplier.Name.Contains(searchString) || product.Name.Contains(searchString)
                             group new { supplier, supply, product } by new { supplier.Name } into grp
                             select new SupplierViewModel()
                             {
                                 ID = grp.FirstOrDefault().supplier.ID,
                                 Name = grp.Key.Name,
                                 NameProduct = grp.FirstOrDefault().product.Name
                             };
                return result.OrderBy(x => x.ID).ToPagedList(page, pageSize);
            }
            else
            {
                var result = from supplier in db.Suppliers
                             join supply in db.SupplyDetails on supplier.ID equals supply.SupplierID
                             join product in db.Products on supply.ProductCode equals product.Code
                             group new { supplier, supply, product } by new { supplier.Name } into grp
                             select new SupplierViewModel()
                             {
                                 ID = grp.FirstOrDefault().supplier.ID,
                                 Name = grp.Key.Name,
                                 NameProduct = grp.FirstOrDefault().product.Name
                             };
                return result.OrderBy(x => x.ID).ToPagedList(page, pageSize);
            }

        }
        public Supplier GetSupplier(long? id, string code)
        {
            if (id.HasValue)
            {
                return db.Suppliers.Find(id);
            }
            else
            {
                return db.Suppliers.Where(x => x.Code == code).FirstOrDefault();
            }
        }
        public bool UpdateSupplier(Supplier model, string userName)
        {
            try
            {
                string action = "";
                var obj = db.Suppliers.Find(model.ID);
                if (obj.Name != model.Name)
                {
                    action += $"| Cập nhật tên nhà cung cấp từ '{obj.Name}' thành '{model.Name}'";
                    obj.Name = model.Name;
                }
                db.SaveChanges();
                SetHistory("update", userName, "nhà cung cấp ", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertSupplier(Supplier model, string userName)
        {
            try
            {
                db.Suppliers.Add(model);
                db.SaveChanges();
                SetHistory("insert", userName, "nhà cung cấp ", $"| Thêm nhà cung cấp '{model.Name}'");
                return true;
            }
            catch { return false; }
        }
        public bool DeleteSupplier(long id, string userName)
        {
            try
            {
                var supplier = db.Suppliers.Find(id);
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                var listObj = db.SupplyDetails.Where(x => x.SupplierID == id).ToList();
                if (listObj != null)
                {
                    foreach (var item in listObj)
                    {
                        db.SupplyDetails.Remove(item);
                    }
                    db.SaveChanges();
                }

                SetHistory("delete", userName, "nhà cung cấp", $" | Xóa nhà cung cấp '{supplier.Name}' ");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng sản phẩm nhà cung cấp
        public bool CheckSupply(SupplyDetail model)
        {
            var supplier = db.Suppliers.Find(model.SupplierID);
            var result = db.SupplyDetails.Where(x => x.SupplierID == supplier.ID & x.ProductCode == model.ProductCode).Count();
            if (result != 0) { return false; } else { return true; }
        }
        public SupplyDetail GetSupply(long id)
        {
            return db.SupplyDetails.Find(id);
        }
        public List<SupplyDetail> GetListSupply(long id)
        {
            return db.SupplyDetails.Where(x => x.SupplierID == id).OrderBy(x => x.ID).ToList();
        }
        public bool UpdateSupply(SupplyDetail model, string userName)
        {
            try
            {
                string action = "";
                var obj = db.SupplyDetails.Find(model.ID);
                if (obj.Price != model.Price)
                {
                    action += $"| Cập nhật giá sản phẩm từ '{obj.Price}' thành '{model.Price}'";
                    obj.Price = model.Price;
                }
                if (obj.ProductCode != model.ProductCode)
                {
                    action += $"| Cập nhật mã sản phẩm từ '{obj.ProductCode}' thành '{model.ProductCode}'";
                    obj.ProductCode = model.ProductCode;
                }
                if (obj.UnitID != model.UnitID)
                {
                    action += $"| Cập nhật đơn vị tính từ '{GetUnit(obj.UnitID).Name}' thành '{GetUnit(model.UnitID).Name}'";
                    obj.ProductCode = model.ProductCode;
                }
                db.SaveChanges();
                SetHistory("update", userName, "sản phẩm cung cấp", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertSupply(SupplyDetail model, string userName, long id)
        {
            try
            {
                var supplier = db.Suppliers.Find(id);
                db.SupplyDetails.Add(model);
                db.SaveChanges();
                var supply = db.Products.Where(x => x.Code == model.ProductCode).FirstOrDefault();
                SetHistory("insert", userName, "sản phẩm cung cấp ", $"| Thêm sản phẩm '{supply.Name}' của nhà cung cấp '{supplier.Name}'");
                return true;
            }
            catch { return false; }
        }
        public bool DeleteSupply(long id, string userName)
        {
            try
            {
                var supply = db.SupplyDetails.Find(id);
                db.SupplyDetails.Remove(supply);
                db.SaveChanges();
                SetHistory("delete", userName, "sản phẩm cung cấp", $" | Xóa sản phẩm '{db.Products.Where(x => x.Code == supply.ProductCode).FirstOrDefault().Name}' khỏi nhà cung cấp '{db.Suppliers.Find(supply.SupplierID).Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng đóng gói
        public bool InsertPackage(Package model, string Username)
        {
            try
            {
                db.Packages.Add(model);
                db.SaveChanges();
                SetHistory("insert", Username, "Cách đóng gói ", $"| Thêm cách đóng gói '{model.Name}'");
                return true;
            }
            catch { return false; }
        }
        public List<Package> ListallPackageToViewBag()
        {
            return db.Packages.ToList();
        }
        public bool UpdatePackage(Package model, string userName)
        {
            try
            {
                string action = "";
                var obj = db.Packages.Find(model.ID);
                if (obj.Name != model.Name)
                {
                    action += $"| Cập nhật tên nhà cung cấp từ '{obj.Name}' thành '{model.Name}'";
                    obj.Name = model.Name;
                }
                db.SaveChanges();
                SetHistory("update", userName, "nhà cung cấp ", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Package GetPackage(long id)
        {
            return db.Packages.Find(id);
        }
        public bool DeletePackage(long id, string userName)
        {
            try
            {
                var model = db.Packages.Find(id);
                db.Packages.Remove(model);
                db.SaveChanges();
                SetHistory("delete", userName, "cách đóng gói", $" | Xóa cách đóng gói tên '{model.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Package> ListAllPackageOnPagedlist(string searchString, int page, int pageSize)
        {
            IQueryable<Package> model = db.Packages;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<Package> ListtAllPackageToViewBag()
        {
            return db.Packages.ToList();
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng khách hàng
        public IEnumerable<Customer> ListAllCustomerOnPagedlist(string searchString,string phone,string address, int page, int pageSize)
        {
            IQueryable<Customer> model = db.Customers;
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
            }
            else
            {
                searchString = "";
            }
            if (!string.IsNullOrEmpty(phone))
            {
                phone = phone.Trim();
            }
            else
            {
                phone = "";
            }
            if (!string.IsNullOrEmpty(address))
            {
                address = address.Trim();
            }
            else
            {
                address = "";
            }
            model = model.Where(x => x.Name.Contains(searchString) && x.Address.Contains(address) && x.Phone.Contains(phone));
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public bool InsertCustomer(Customer model, string userName)
        {
            try
            {
                if (model.Address == null)
                {
                    model.Address = "Chưa có địa chỉ";
                }
                if (model.Phone == null)
                {
                    model.Phone = "Chưa có SĐT";
                }
                db.Customers.Add(model);
                db.SaveChanges();
                SetHistory("insert", userName, "khách hàng ", $"| Thêm khách hàng tên '{model.Name}'");
                return true;
            }
            catch { return false; }
        }
        public Customer GetCustomer(long id)
        {
            return db.Customers.Find(id);
        }
        public bool UpdateCustomer(Customer model, string userName)
        {
            try
            {
                string action = "";
                var obj = db.Customers.Find(model.ID);
                if (obj.Name != model.Name)
                {
                    action += $"| Cập nhật tên khách hàng từ '{obj.Name}' thành '{model.Name}'";
                    obj.Name = model.Name;
                }
                if (obj.Address != model.Address)
                {
                    action += $"| Cập nhật địa chỉ khách hàng '{obj.Name}' từ '{obj.Address}' thành '{model.Address}'";
                    obj.Address = model.Address;
                }
                if (obj.Phone != model.Phone)
                {
                    action += $"| Cập nhật số điện thoại khách hàng '{obj.Name}' từ '{obj.Phone}' thành '{model.Phone}'";
                    obj.Phone = model.Phone;
                }
                db.SaveChanges();
                SetHistory("update", userName, " khách hàng ", action);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCustomer(long id, string userName)
        {
            try
            {
                var model = db.Customers.Find(id);
                db.Customers.Remove(model);
                db.SaveChanges();
                SetHistory("delete", userName, "khách hàng", $" | Xóa khách hàng tên '{model.Name}'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng phiếu nhập
        public string GetNameSupplier(long id)
        {
            var supplier = db.Suppliers.Find(id);
            return supplier.Name;
        }
        public IEnumerable<ImportViewModel> ListAllImportOnPagedList(string searchString,string productName,string note, DateTime? dateImport, bool status, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
            }
            else
            {
                searchString = "";
            }
            if (!string.IsNullOrEmpty(productName))
            {
                productName = productName.Trim();
            }
            else
            {
                productName = "";
            }
            if (!string.IsNullOrEmpty(note))
            {
                note = note.Trim();
            }
            else
            {
                note = "";
            }
            if (dateImport.HasValue)
            {
                var result = (from import in db.Imports
                             join supplier in db.Suppliers on import.SupplierID equals supplier.ID
                             join supply in db.ImportDetails on import.Code equals supply.ImportCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             where import.Note.Contains(note) && product.Name.Contains(productName) && supplier.Name.Contains(searchString) && import.ImportDelete == status && import.Time.Year == dateImport.Value.Year && import.Time.Month== dateImport.Value.Month && import.Time.Day==dateImport.Value.Day                            
                             select new ImportViewModel()
                             {
                                 ID = import.ID,
                                 Code = import.Code,
                                 NameSupplier = supplier.Name,
                                 Note = import.Note,
                                 Time = import.Time,
                                 ImportDelete = import.ImportDelete,
                                 NameSupply = product.Code,
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            else
            {
                var result = (from import in db.Imports
                             join supplier in db.Suppliers on import.SupplierID equals supplier.ID
                             join supply in db.ImportDetails on import.Code equals supply.ImportCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             where import.Note.Contains(note) && product.Name.Contains(productName) && supplier.Name.Contains(searchString) && import.ImportDelete == status
                             select new ImportViewModel()
                             {
                                 ID = import.ID,
                                 Code = import.Code,
                                 NameSupplier = supplier.Name,
                                 Note = import.Note,
                                 Time = import.Time,
                                 ImportDelete = import.ImportDelete,
                                 NameSupply = product.Code,
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            
        }
        public ImportForm GetAllProduct(long id)
        {
            var importObj = new ImportForm();
            var importReceipt = db.Imports.Find(id);
            var listImport = db.ImportDetails.Where(x => x.ImportCode == importReceipt.Code).ToList();
            importObj.Import = importReceipt;
            importObj.importDetails = listImport;
            return importObj;
        }
        public bool InsertImport(List<ProductModel> listProduct, string userName)
        {
            try
            {
                if (listProduct == null)
                {
                    return false;
                }
                var newcode = Functions.CreateCode("IP");
                if (listProduct.Count == 0)
                {
                    return false;
                }
                else
                {
                    Import phieuxuat = new Import();
                    phieuxuat.Code = newcode;
                    var supplierVar = GetSupplier(null, listProduct.FirstOrDefault().SupplierCode);
                    phieuxuat.SupplierID = supplierVar.ID;
                    phieuxuat.Time = listProduct.First().Time;
                    if (string.IsNullOrEmpty(listProduct.First().Note))
                    {
                        phieuxuat.Note = "";
                    }
                    else
                    {
                        phieuxuat.Note = listProduct.First().Note;
                    }              
                    db.Imports.Add(phieuxuat);
                    db.SaveChanges();
                    foreach (var item in listProduct)
                    {
                        ImportDetail import = new ImportDetail();
                        import.ImportCode = phieuxuat.Code;
                        import.ImportPrice = decimal.Parse(Functions.RemoveCharacters(item.Price));
                        import.ProductCode = item.ProductCode;
                        import.Quantity = item.Quantity;
                        import.PackageID = item.PackageID;
                        import.UnitID = item.UnitID;
                        db.ImportDetails.Add(import);
                        //Xử lý thêm số lượng
                        Product product = db.Products.Where(x => x.Code == import.ProductCode).First();
                        var productmain = db.Products.Find(product.ID);
                        long soluongcongthem = import.Quantity;
                        productmain.Quantity = productmain.Quantity + soluongcongthem;
                        db.SaveChanges();
                    }
                    List<string> Namelist = new List<string>();
                    foreach (var items in db.SupplyDetails.Where(x => x.SupplierID == phieuxuat.SupplierID).ToList())
                    {
                        Namelist.Add(items.ProductCode);
                    }
                    //Xử lý thêm sản phẩm vào nhà cung cấp
                    var supplier = db.Suppliers.Find(phieuxuat.SupplierID);
                    foreach (var item in listProduct)
                    {
                        if (Namelist.Contains(item.ProductCode.ToString()))
                        {
                            SupplyDetail product = db.SupplyDetails.Where(x => x.ProductCode == item.ProductCode).First();
                            product.Price = decimal.Parse(Functions.RemoveCharacters(item.Price));
                            db.SaveChanges();
                        }
                        else
                        {
                            SupplyDetail supplyDetail = new SupplyDetail();
                            supplyDetail.ProductCode = item.ProductCode;
                            supplyDetail.Price = decimal.Parse(Functions.RemoveCharacters(item.Price));
                            supplyDetail.UnitID = item.UnitID;
                            supplyDetail.SupplierID = phieuxuat.SupplierID;
                            db.SupplyDetails.Add(supplyDetail);
                            db.SaveChanges();
                        }
                    }
                    SetHistoryRecepit("insert", newcode, userName, "phiếu nhập");
                    return true;
                }
            }
            catch(Exception ex)
            {
                
                return false;
            }
        }
        public bool UpdateImport(List<ProductModel> model, string userName)
        {
            try
            {
                var changeText = "";
                var obj = model.First();
                var importReceipt = db.Imports.Where(x => x.Code == obj.Code).First();
                if (obj.Note == null)
                {
                    obj.Note = "";
                }
                if (importReceipt.Note.Trim() != obj.Note.Trim())
                {
                    if(string.IsNullOrEmpty(obj.Note.Trim()))
                    {
                        importReceipt.Note = "";
                        changeText += $"Thay đổi ghi chú từ '{importReceipt.Note}' thành '{obj.Note}'|";
                    }
                    else
                    {
                        changeText += $"Thay đổi ghi chú từ '{importReceipt.Note}' thành '{obj.Note}'|";
                        importReceipt.Note = obj.Note;
                    }

                }
                var supplierVar = db.Suppliers.Where(x => x.Code == obj.SupplierCode).FirstOrDefault();
                if (importReceipt.SupplierID != supplierVar.ID)
                {
                    changeText += $"Thay đổi NCC từ '{db.Suppliers.Find(importReceipt.SupplierID).Name}' thành '{db.Suppliers.Find(supplierVar.ID).Name}' |";
                    importReceipt.SupplierID = supplierVar.ID;
                }
                if (importReceipt.Time != obj.Time)
                {
                    changeText += $"Thay đổi thời gian từ '{importReceipt.Time.ToString("dd/mm/yyyy HH:mm")}' thành '{obj.Time.ToString("dd/mm/yyyy HH:mm")}'|";
                    importReceipt.Time = obj.Time;
                }
                var listObj = db.ImportDetails.Where(x => x.ImportCode == obj.Code).ToList();
                //Thêm list Product trước và sau;
                var listtruoc = new List<ListProduct>();
                var listsau = new List<ListProduct>();
                foreach (var item in listObj)
                {
                    var product = new ListProduct();
                    product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                    product.Quantity = item.Quantity;
                    product.Price = item.ImportPrice;
                    product.Unit = db.Units.Find(item.UnitID).Name;
                    product.Package = db.Packages.Find(item.PackageID).Name;
                    listtruoc.Add(product);
                }
                foreach (var item in model)
                {
                    var product = new ListProduct();
                    product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                    product.Quantity = item.Quantity;
                    product.Price = Convert.ToDecimal(item.Price);
                    product.Unit = db.Units.Find(item.UnitID).Name;
                    product.Package = db.Packages.Find(item.PackageID).Name;
                    listsau.Add(product);
                }
                //So sánh và add thông tin lịch sử;
                if (listtruoc != listsau)
                {
                    string textlisttruoc = "";
                    string textlistsau = "";
                    foreach (var item in listtruoc)
                    {
                        textlisttruoc += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} | ĐG: {item.Package}";
                    }
                    foreach (var item in listsau)
                    {
                        textlistsau += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} | ĐG: {item.Package}";
                    }
                    changeText += $"Thay đổi danh sách| TỪ |{textlisttruoc} THÀNH | {textlistsau}";
                }
                foreach (var item in listObj)
                {
                    var product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity - item.Quantity;
                    db.ImportDetails.Remove(item);
                    //Xóa sản phẩm khỏi nhà cung cấp
                }
                foreach (var item in model)
                {
                    var importDetail = new ImportDetail();
                    importDetail.ImportCode = item.Code;
                    importDetail.ImportPrice = Decimal.Parse(item.Price);
                    importDetail.ProductCode = item.ProductCode;
                    importDetail.Quantity = item.Quantity;
                    importDetail.PackageID = item.PackageID;
                    importDetail.UnitID = item.UnitID;
                    var product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity + item.Quantity;
                    db.ImportDetails.Add(importDetail);
                    db.SaveChanges();
                }
                SetHistoryRecepit("update", importReceipt.Code, userName, "phiếu nhập", changeText);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteImport(long id, string userName)
        {
            try
            {
                var importRecepit = db.Imports.Find(id);
                var listDetails = db.ImportDetails.Where(x => x.ImportCode == importRecepit.Code).ToList();
                foreach (var item in listDetails)
                {
                    item.ImportDetailDelete = true;
                    var product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity - item.Quantity;
                    db.SaveChanges();
                }
                SetHistoryRecepit("delete", importRecepit.Code, userName, "phiếu nhập");
                importRecepit.ImportDelete = true;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ImportModel> GetDataImport(string code)
        {
            var import = db.Imports.Where(x => x.Code == code).FirstOrDefault();
            var imports = db.ImportDetails.Where(x => x.ImportCode == code).ToList();
            decimal tongtien = 0;
            List<ImportModel> listImport = new List<ImportModel>();
            foreach(var item in imports)
            {
                tongtien += item.Quantity * item.ImportPrice;
            }
            foreach(var item in imports)
            {
                var model = new ImportModel();
                model.Code = import.Code;
                model.Note = import.Note;
                model.PackageName = db.Packages.Find(item.PackageID).Name;
                model.Price = item.ImportPrice;
                model.Quantity = item.Quantity;
                model.ProductName = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                model.SupplierName = db.Suppliers.Find(import.SupplierID).Name;
                model.Time = import.Time.ToString("dd-MM-yyyy HH:mm");
                model.Total = tongtien;
                model.UnitName = db.Units.Find(item.UnitID).Name;
                listImport.Add(model);
            }
            return listImport;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng phiếu xuất
        public IEnumerable<ExportViewModel> ListAllExportOnPagedlist(string searchString,string note,string nameProduct,string staffName,string userName, DateTime? dateExport, bool? statusExoport, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
            }
            else
            {
                searchString = "";
            }
            if (!string.IsNullOrEmpty(note))
            {
                note = note.Trim();
            }
            else
            {
                note = "";
            }
            if (!string.IsNullOrEmpty(nameProduct))
            {
                nameProduct = nameProduct.Trim();
            }
            else
            {
                nameProduct = "";
            }
            if (!string.IsNullOrEmpty(staffName))
            {
                staffName = staffName.Trim();
            }
            else
            {
                staffName = "";
            }
            if (!string.IsNullOrEmpty(userName))
            {
                userName = userName.Trim();
            }
            else
            {
                userName = "";
            }
            if (dateExport.HasValue && statusExoport.HasValue)
            {
                var result = (from export in db.Exports
                             join customer in db.Customers on export.CustomerCode equals customer.CustomerCode
                             join supply in db.ExportDetails on export.Code equals supply.ExportCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on export.UserID equals users.ID
                             where export.Note.Contains(note) && customer.Name.Contains(searchString) && export.Delivery.Contains(staffName) && users.Name.Contains(userName) && product.Name.Contains(nameProduct) && export.Status == statusExoport.Value && export.Time.Year == dateExport.Value.Year && export.Time.Month == dateExport.Value.Month && export.Time.Day == dateExport.Value.Day && export.ExportDelete == false
                             select new ExportViewModel()
                             {
                                 Code = export.Code,
                                 CustomerName = customer.Name,
                                 Note = export.Note,
                                 Time = export.Time,
                                 Delivery = export.Delivery,
                                 ExportDelete = export.ExportDelete,
                                 NameUser = users.Name,
                                 Status = export.Status
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            else if (!dateExport.HasValue && statusExoport.HasValue)
            {
                var result = (from export in db.Exports
                             join customer in db.Customers on export.CustomerCode equals customer.CustomerCode
                             join supply in db.ExportDetails on export.Code equals supply.ExportCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on export.UserID equals users.ID
                             where export.Note.Contains(note) && customer.Name.Contains(searchString) && export.Delivery.Contains(staffName) && users.Name.Contains(userName) && product.Name.Contains(nameProduct) && export.ExportDelete == false && export.Status == statusExoport.Value
                             select new ExportViewModel()
                             {
                                 Code = export.Code,
                                 CustomerName = customer.Name,
                                 Note = export.Note,
                                 Time = export.Time,
                                 Delivery = export.Delivery,
                                 ExportDelete = export.ExportDelete,
                                 NameUser = users.Name,
                                 Status = export.Status
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            else if (dateExport.HasValue && !statusExoport.HasValue)
            {
                var result = (from export in db.Exports
                             join customer in db.Customers on export.CustomerCode equals customer.CustomerCode
                             join supply in db.ExportDetails on export.Code equals supply.ExportCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on export.UserID equals users.ID                           
                             where export.Note.Contains(note) && customer.Name.Contains(searchString) && export.Delivery.Contains(staffName) && users.Name.Contains(userName) && product.Name.Contains(nameProduct) && export.Time.Year == dateExport.Value.Year && export.Time.Month == dateExport.Value.Month && export.Time.Day == dateExport.Value.Day && export.ExportDelete == false
                             select new ExportViewModel()
                             {
                                 Code = export.Code,
                                 CustomerName = customer.Name,
                                 Note = export.Note,
                                 Time = export.Time,
                                 Delivery = export.Delivery,
                                 ExportDelete = export.ExportDelete,
                                 NameUser = users.Name,
                                 Status = export.Status
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            else
            {
                var result = (from export in db.Exports
                             join customer in db.Customers on export.CustomerCode equals customer.CustomerCode
                             join supply in db.ExportDetails on export.Code equals supply.ExportCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on export.UserID equals users.ID
                             where export.Note.Contains(note) && customer.Name.Contains(searchString) && export.Delivery.Contains(staffName) && users.Name.Contains(userName) && product.Name.Contains(nameProduct) && export.ExportDelete == false
                             select new ExportViewModel()
                             {
                                 Code = export.Code,
                                 CustomerName = customer.Name,
                                 Note = export.Note,
                                 Time = export.Time,
                                 Delivery = export.Delivery,
                                 ExportDelete = export.ExportDelete,
                                 NameUser = users.Name,
                                 Status = export.Status
                             }).Distinct();
            return result.OrderByDescending(x=>x.Time).ToPagedList(page,pageSize);
            }
        }
        public ExportForm GetExportForm(long id)
        {
            var exportForm = new ExportForm();
            var exportReceipt = db.Exports.Find(id);
            var exportDetails = db.ExportDetails.Where(x => x.ExportCode == exportReceipt.Code).ToList();
            exportForm.Export = exportReceipt;
            exportForm.exportDetails = exportDetails;
            return exportForm;
        }
        public bool InsertExport(List<ListExport> model, string userName)
        {
            try
            {
                var Export = new Export();
                Export.Code = Functions.CreateCode("EP");
                if (model.First().CustomerCode == null)
                {
                    var customer = new Customer();
                    customer.Name = model.First().NameCustomer;
                    customer.CustomerCode = Functions.CreateCode("KH");
                    InsertCustomer(customer, userName);
                    Export.CustomerCode = customer.CustomerCode;
                }
                else
                {
                    Export.CustomerCode = model.First().CustomerCode;
                }
                if(model.First().Delivery == null)
                {
                    Export.Delivery = " ";
                }
                else
                {
                    Export.Delivery = model.First().Delivery;
                }
                if (model.First().Note == null)
                {
                    Export.Note = " ";
                }
                else
                {
                    Export.Note = model.First().Note;
                }
                Export.Status = false;
                Export.Time = model.First().Time;
                Export.UserID = db.Users.Where(x => x.UserName == userName).First().ID;
                db.Exports.Add(Export);
                foreach (var item in model)
                {
                    var detail = new ExportDetail();
                    detail.ExportCode = Export.Code;
                    detail.Price = Decimal.Parse(Functions.RemoveCharacters(item.Price));
                    detail.ProductCode = item.ProductCode;
                    detail.Quantity = item.Quantity;
                    detail.UnitID = item.UnitID;
                    db.ExportDetails.Add(detail);

                }
                // Trừ sản phẩm khi xuất
                foreach (var items in model)
                {
                    var product = db.Products.Where(x => x.Code == items.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity - items.Quantity;
                }
                SetHistoryRecepit("insert", Export.Code, userName, "phiếu xuất");
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                var loi = ex;
                return false;
            }
        }
        public bool UpdateExport(List<ListExport> model, string userName)
        {
            try
            {
                string changeText = "";
                var obj = model.First();
                if(model.FirstOrDefault().Note == null)
                {
                    foreach(var item in model)
                    {
                        item.Note = " ";
                    }
                }
                if(model.FirstOrDefault().Delivery == null)
                {
                    foreach(var item in model)
                    {
                        item.Delivery = " ";
                    }
                }
                var exportReceipt = db.Exports.Where(x => x.Code == obj.Code).First();
                if (exportReceipt.Note != obj.Note)
                {
                    changeText += $"Thay đổi ghi chú từ '{exportReceipt.Note}' thành '{obj.Note}' | ";
                    exportReceipt.Note = obj.Note;
                }
                if (exportReceipt.CustomerCode != obj.CustomerCode)
                {
                    changeText += $"Thay đổi tên KH từ '{db.Customers.Where(x => x.CustomerCode == exportReceipt.CustomerCode).FirstOrDefault().Name}' thành '{db.Customers.Where(x => x.CustomerCode == obj.CustomerCode).FirstOrDefault().Name}' | ";
                    exportReceipt.CustomerCode = obj.CustomerCode;
                }
                if (exportReceipt.Delivery != obj.Delivery)
                {
                    changeText += $"Thay đổi NV giao từ '{exportReceipt.Delivery}' thành '{obj.Delivery}' | ";
                    exportReceipt.Delivery = obj.Delivery;
                }
                if (exportReceipt.Note != obj.Note)
                {
                    changeText += $"Thay đổi ghi chú từ '{exportReceipt.Note}' thành '{obj.Note}' | ";
                    exportReceipt.Note = obj.Note;
                }
                if (exportReceipt.Time != obj.Time)
                {
                    changeText += $"Thay đổi thời gian từ '{exportReceipt.Time}' thành '{obj.Time}' | ";
                    exportReceipt.Time = obj.Time;
                }
                if (exportReceipt.Status != obj.Status)
                {
                    changeText += $"Thay đổi trạng thái từ '{GetStatus(exportReceipt.Status)}' thành '{GetStatus(obj.Status)}' | ";
                    exportReceipt.Status = obj.Status;
                }
                var listObj = db.ExportDetails.Where(x => x.ExportCode == obj.Code).ToList();
                //Thêm list Product trước và sau;
                var listtruoc = new List<ListProduct>();
                var listsau = new List<ListProduct>();
                foreach (var item in listObj)
                {
                    var product = new ListProduct();
                    product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                    product.Quantity = item.Quantity;
                    product.Price = item.Price;
                    product.Unit = db.Units.Find(item.UnitID).Name;
                    listtruoc.Add(product);
                }
                foreach (var item in model)
                {
                    var product = new ListProduct();
                    product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                    product.Quantity = item.Quantity;
                    product.Price = Convert.ToDecimal(item.Price);
                    product.Unit = db.Units.Find(item.UnitID).Name;
                    listsau.Add(product);
                }
                //So sánh và add thông tin lịch sử;
                if (listtruoc != listsau)
                {
                    string textlisttruoc = "";
                    string textlistsau = "";
                    foreach (var item in listtruoc)
                    {
                        textlisttruoc += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} |";
                    }
                    foreach (var item in listsau)
                    {
                        textlistsau += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} |";
                    }
                    changeText += $"Thay đổi danh sách| TỪ |{textlisttruoc} THÀNH |{textlistsau}";
                }
                //Xóa list cũ
                foreach (var item in listObj)
                {
                    Product product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity + item.Quantity;
                    db.SaveChanges();
                    db.ExportDetails.Remove(item);
                }
                //Thêm list mới
                foreach (var item in model)
                {
                    var exportDetail = new ExportDetail();
                    exportDetail.ExportCode = item.Code;
                    exportDetail.Price = Decimal.Parse(Functions.RemoveCharacters(item.Price));
                    exportDetail.ProductCode = item.ProductCode;
                    exportDetail.Quantity = item.Quantity;
                    exportDetail.UnitID = item.UnitID;
                    Product product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity - item.Quantity;
                    db.ExportDetails.Add(exportDetail);
                    db.SaveChanges();
                }
                SetHistoryRecepit("update", exportReceipt.Code, userName, "phiếu xuất", changeText);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int UpdateExportForStaff(List<ListExport> model,string userName)
        {
            try
            {
                string codeExport = model.FirstOrDefault().Code;
                var export = db.Exports.Where(x => x.Code == codeExport).FirstOrDefault();
                if (export.Status == false)
                {
                    string changeText = "";
                    var obj = model.First();
                    if (model.FirstOrDefault().Note == null)
                    {
                        foreach (var item in model)
                        {
                            item.Note = " ";
                        }
                    }
                    if (model.FirstOrDefault().Delivery == null)
                    {
                        foreach (var item in model)
                        {
                            item.Delivery = " ";
                        }
                    }
                    var exportReceipt = db.Exports.Where(x => x.Code == obj.Code).First();
                    if (exportReceipt.Note != obj.Note)
                    {
                        changeText += $"Thay đổi ghi chú từ '{exportReceipt.Note}' thành '{obj.Note}' | ";
                        exportReceipt.Note = obj.Note;
                    }
                    if (exportReceipt.CustomerCode != obj.CustomerCode)
                    {
                        changeText += $"Thay đổi tên KH từ '{db.Customers.Where(x => x.CustomerCode == exportReceipt.CustomerCode).FirstOrDefault().Name}' thành '{db.Customers.Where(x => x.CustomerCode == obj.CustomerCode).FirstOrDefault().Name}' | ";
                        exportReceipt.CustomerCode = obj.CustomerCode;
                    }
                    if (exportReceipt.Delivery != obj.Delivery)
                    {
                        changeText += $"Thay đổi NV giao từ '{exportReceipt.Delivery}' thành '{obj.Delivery}' | ";
                        exportReceipt.Delivery = obj.Delivery;
                    }
                    if (exportReceipt.Note != obj.Note)
                    {
                        changeText += $"Thay đổi ghi chú từ '{exportReceipt.Note}' thành '{obj.Note}' | ";
                        exportReceipt.Note = obj.Note;
                    }
                    if (exportReceipt.Time != obj.Time)
                    {
                        changeText += $"Thay đổi thời gian từ '{exportReceipt.Time}' thành '{obj.Time}' | ";
                        exportReceipt.Time = obj.Time;
                    }
                    if (exportReceipt.Status != obj.Status)
                    {
                        changeText += $"Thay đổi trạng thái từ '{GetStatus(exportReceipt.Status)}' thành '{GetStatus(obj.Status)}' | ";
                        exportReceipt.Status = obj.Status;
                    }
                    var listObj = db.ExportDetails.Where(x => x.ExportCode == obj.Code).ToList();
                    //Thêm list Product trước và sau;
                    var listtruoc = new List<ListProduct>();
                    var listsau = new List<ListProduct>();
                    foreach (var item in listObj)
                    {
                        var product = new ListProduct();
                        product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                        product.Quantity = item.Quantity;
                        product.Price = item.Price;
                        product.Unit = db.Units.Find(item.UnitID).Name;
                        listtruoc.Add(product);
                    }
                    foreach (var item in model)
                    {
                        var product = new ListProduct();
                        product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                        product.Quantity = item.Quantity;
                        product.Price = Convert.ToDecimal(item.Price);
                        product.Unit = db.Units.Find(item.UnitID).Name;
                        listsau.Add(product);
                    }
                    //So sánh và add thông tin lịch sử;
                    if (listtruoc != listsau)
                    {
                        string textlisttruoc = "";
                        string textlistsau = "";
                        foreach (var item in listtruoc)
                        {
                            textlisttruoc += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} |";
                        }
                        foreach (var item in listsau)
                        {
                            textlistsau += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} |";
                        }
                        changeText += $"Thay đổi danh sách| TỪ |{textlisttruoc} THÀNH |{textlistsau}";
                    }
                    //Xóa list cũ
                    foreach (var item in listObj)
                    {
                        Product product = new Product();
                        product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                        product.Quantity = product.Quantity + item.Quantity;
                        db.SaveChanges();
                        db.ExportDetails.Remove(item);
                    }
                    //Thêm list mới
                    foreach (var item in model)
                    {
                        var exportDetail = new ExportDetail();
                        exportDetail.ExportCode = item.Code;
                        exportDetail.Price = Decimal.Parse(Functions.RemoveCharacters(item.Price));
                        exportDetail.ProductCode = item.ProductCode;
                        exportDetail.Quantity = item.Quantity;
                        exportDetail.UnitID = item.UnitID;
                        Product product = new Product();
                        product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                        product.Quantity = product.Quantity - item.Quantity;
                        db.ExportDetails.Add(exportDetail);
                        db.SaveChanges();
                    }
                    SetHistoryRecepit("update", exportReceipt.Code, userName, "phiếu xuất", changeText);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public bool DeleteExport(long id, string userName)
        {
            try
            {
                var exportRecepit = db.Exports.Find(id);
                var listDetails = db.ExportDetails.Where(x => x.ExportCode == exportRecepit.Code).ToList();
                foreach (var item in listDetails)
                {
                    item.ExportDetailDelete = true;
                    var product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity + item.Quantity;
                    db.SaveChanges();
                }
                SetHistoryRecepit("delete", exportRecepit.Code, userName, "phiếu xuất");
                exportRecepit.ExportDelete = true;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteExportForStaff(long id, string userName)
        {
            try
            {
                var export = db.Exports.Find(id);
                if(export.Status == false)
                {
                    var exportRecepit = db.Exports.Find(id);
                    var listDetails = db.ExportDetails.Where(x => x.ExportCode == exportRecepit.Code).ToList();
                    foreach (var item in listDetails)
                    {
                        item.ExportDetailDelete = true;
                        var product = new Product();
                        product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                        product.Quantity = product.Quantity + item.Quantity;
                        db.SaveChanges();
                    }
                    SetHistoryRecepit("delete", exportRecepit.Code, userName, "phiếu xuất");
                    exportRecepit.ExportDelete = true;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {
                return false;
            }
        }
        public void ChangeStatus(string code,string type)
        {
            switch (type)
            {
                case "export":
                    var receipt = db.Exports.Where(x => x.Code == code).FirstOrDefault();
                    if(receipt.Status == true)
                    {
                        receipt.Status = false;
                    }
                    else
                    {
                        receipt.Status = true;
                    }
                    db.SaveChanges();
                    break;
                case "refund":
                    var refund = db.Refunds.Where(x => x.Code == code).FirstOrDefault();
                    if (refund.Status == true)
                    {
                        refund.Status = false;
                    }
                    else
                    {
                        refund.Status = true;
                    }
                    db.SaveChanges();
                    break;
                default:
                    break;
            }
        }
        public List<ExportModel> GetDataExport(string code)
        {
            var export = db.Exports.Where(x => x.Code == code).FirstOrDefault();
            var exports = db.ExportDetails.Where(x => x.ExportCode == code).ToList();
            decimal tongtien = 0;
            List<ExportModel> listExport = new List<ExportModel>();
            foreach (var item in exports)
            {
                tongtien += (item.Quantity * item.Price);
            }
            foreach (var item in exports)
            {
                var model = new ExportModel();
                model.CustomerName = db.Customers.Where(x => x.CustomerCode == export.CustomerCode).FirstOrDefault().Name;
                model.Delivery = export.Delivery;
                model.ExportCode = code;
                model.Note = export.Note;
                model.Price = item.Price;
                model.ProductName = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                model.Quantity = item.Quantity;
                model.Staff = db.Users.Find(export.UserID).Name;
                model.Time = export.Time.ToString("dd-MM-yyyy HH:mm");
                model.UnitName = db.Units.Find(item.UnitID).Name;
                model.Total = tongtien;
                listExport.Add(model);
            }
            return listExport;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng phiếu trả hàng
        public IEnumerable<RefundViewModel> ListAllRefundOnPagedlist(string searchString,string note,string nameProduct,string nameStaff,bool? status, DateTime? dateRefund, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
            }
            else
            {
                searchString = "";
            }
            if (!string.IsNullOrEmpty(note))
            {
                note = note.Trim();
            }
            else
            {
                note = "";
            }
            if (!string.IsNullOrEmpty(nameProduct))
            {
                nameProduct = nameProduct.Trim();
            }
            else
            {
                nameProduct = "";
            }
            if (!string.IsNullOrEmpty(nameStaff))
            {
                nameStaff = nameStaff.Trim();
            }
            else
            {
                nameStaff = "";
            }
            if (status.HasValue && dateRefund.HasValue)
            {
                var result = (from refund in db.Refunds
                             join customer in db.Customers on refund.CustomerCode equals customer.CustomerCode
                             join supply in db.RefundDetails on refund.Code equals supply.RefundCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on refund.UserID equals users.ID                            
                             where refund.Note.Contains(note) && refund.Status == status && customer.Name.Contains(searchString) && users.Name.Contains(nameStaff) && product.Name.Contains(nameProduct) && refund.Time.Year == dateRefund.Value.Year && refund.Time.Month == dateRefund.Value.Month && refund.Time.Day == dateRefund.Value.Day && refund.RefundDelete == false
                             select new RefundViewModel()
                             {
                                 Code = refund.Code,
                                 CustomerName = customer.Name,
                                 NameUser = users.Name,
                                 Note = refund.Note,
                                 Time = refund.Time,
                                 RefundDelete = refund.RefundDelete,
                                 Status = refund.Status,
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            else if(status.HasValue && !dateRefund.HasValue)
            {
                var result = (from refund in db.Refunds
                             join customer in db.Customers on refund.CustomerCode equals customer.CustomerCode
                             join supply in db.RefundDetails on refund.Code equals supply.RefundCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on refund.UserID equals users.ID                            
                             where refund.Note.Contains(note) && customer.Name.Contains(searchString) && users.Name.Contains(nameStaff) && product.Name.Contains(nameProduct) && refund.RefundDelete == false && refund.Status== status
                             select new RefundViewModel()
                             {
                                 Code = refund.Code,
                                 CustomerName = customer.Name,
                                 NameUser = users.Name,
                                 Note = refund.Note,
                                 Time = refund.Time,
                                 RefundDelete = refund.RefundDelete,
                                 Status = refund.Status,
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            else if(!status.HasValue && dateRefund.HasValue)
            {
                var result = (from refund in db.Refunds
                             join customer in db.Customers on refund.CustomerCode equals customer.CustomerCode
                             join supply in db.RefundDetails on refund.Code equals supply.RefundCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on refund.UserID equals users.ID
                             where refund.Note.Contains(note) && customer.Name.Contains(searchString) && users.Name.Contains(nameStaff) && product.Name.Contains(nameProduct) && refund.Time.Year == dateRefund.Value.Year && refund.Time.Month == dateRefund.Value.Month && refund.Time.Day == dateRefund.Value.Day && refund.RefundDelete == false
                             select new RefundViewModel()
                             {
                                 Code = refund.Code,
                                 CustomerName = customer.Name,
                                 NameUser = users.Name,
                                 Note = refund.Note,
                                 Time = refund.Time,
                                 RefundDelete = refund.RefundDelete,
                                 Status = refund.Status,
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            else
            {
                var result = (from refund in db.Refunds
                             join customer in db.Customers on refund.CustomerCode equals customer.CustomerCode
                             join supply in db.RefundDetails on refund.Code equals supply.RefundCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on refund.UserID equals users.ID                          
                             where refund.Note.Contains(note) && customer.Name.Contains(searchString) && users.Name.Contains(nameStaff) && product.Name.Contains(nameProduct) && refund.RefundDelete == false
                             select new RefundViewModel()
                             {
                                 Code = refund.Code,
                                 CustomerName = customer.Name,
                                 NameUser = users.Name,
                                 Note = refund.Note,
                                 Time = refund.Time,
                                 RefundDelete = refund.RefundDelete,
                                 Status = refund.Status,
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
        }
        public RefundForm GetRefundForm(long id)
        {
            var refundForm = new RefundForm();
            var refundReceipt = db.Refunds.Find(id);
            var refundDetails = db.RefundDetails.Where(x => x.RefundCode == refundReceipt.Code).ToList();
            refundForm.Refund = refundReceipt;
            refundForm.refundDetails = refundDetails;
            return refundForm;
        }
        public bool InsertRefund(List<ListRefund> model, string username)
        {
            try
            {
                var refund = new Refund();
                refund.Code = Functions.CreateCode("EP");
                if (model.First().CustomerCode == null)
                {
                    var customer = new Customer();
                    customer.Name = model.First().NameCustomer;
                    customer.CustomerCode = Functions.CreateCode("KH");
                    InsertCustomer(customer, username);
                    refund.CustomerCode = customer.CustomerCode;
                }
                else
                {
                    refund.CustomerCode = model.First().CustomerCode;
                }
                if (model.First().Note == null)
                {
                    refund.Note = " ";
                }
                else
                {
                    refund.Note = model.First().Note;
                }
                refund.Status = false;
                refund.Time = model.First().Time;
                refund.UserID = db.Users.Where(x => x.UserName == username).First().ID;
                db.Refunds.Add(refund);
                foreach (var item in model)
                {
                    var detail = new RefundDetail();
                    detail.RefundCode = refund.Code;
                    detail.Price = Decimal.Parse(Functions.RemoveCharacters(item.Price));
                    detail.ProductCode = item.ProductCode;
                    detail.Quantity = item.Quantity;
                    detail.UnitID = item.UnitID;
                    db.RefundDetails.Add(detail);

                }
                // Cộng sản phẩm vào kho khi trả hàng
                foreach (var items in model)
                {
                    var product = db.Products.Where(x => x.Code == items.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity + items.Quantity;
                }
                SetHistoryRecepit("insert", refund.Code, username, "phiếu trả hàng");
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                var loi = ex;
                return false;
            }
        }
        public bool UpdateRefund(List<ListRefund> model, string userName)
        {
            try
            {
                var changeText = "";
                var obj = model.First();
                var refundReceipt = db.Refunds.Where(x => x.Code == obj.Code).First();
                if (refundReceipt.Note != obj.Note)
                {
                    changeText += $"Thay đổi ghi chú từ '{refundReceipt.Note}' thành '{obj.Note}' | ";
                    refundReceipt.Note = obj.Note;
                }
                if (refundReceipt.CustomerCode != obj.CustomerCode)
                {
                    changeText += $"Thay đổi tên KH từ '{db.Customers.Where(x => x.CustomerCode == refundReceipt.CustomerCode).First().Name}' thành '{db.Customers.Where(x => x.CustomerCode == obj.CustomerCode).First().Name}' | ";
                    refundReceipt.CustomerCode = obj.CustomerCode;
                }
                if (refundReceipt.Time != obj.Time)
                {
                    changeText += $"Thay đổi thời gian từ '{refundReceipt.Time.ToString("dd/MM/yyyy HH:mm")}' thành '{obj.Time.ToString("dd/MM/yyyy HH:mm")}' | ";
                    refundReceipt.Time = obj.Time;
                }
                if (refundReceipt.Status != obj.Status)
                {
                    changeText += $"Thay đổi trạng thái từ '{GetStatus(refundReceipt.Status)}' thành '{GetStatus(obj.Status)}' | ";
                    refundReceipt.Status = obj.Status;
                }
                var listObj = db.RefundDetails.Where(x => x.RefundCode == obj.Code).ToList();
                //Thêm list Product trước và sau;
                var listtruoc = new List<ListProduct>();
                var listsau = new List<ListProduct>();
                foreach (var item in listObj)
                {
                    var product = new ListProduct();
                    product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                    product.Quantity = item.Quantity;
                    product.Price = item.Price;
                    product.Unit = db.Units.Find(item.UnitID).Name;
                    listtruoc.Add(product);
                }
                foreach (var item in model)
                {
                    var product = new ListProduct();
                    product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                    product.Quantity = item.Quantity;
                    product.Price = Convert.ToDecimal(item.Price);
                    product.Unit = db.Units.Find(item.UnitID).Name;
                    listsau.Add(product);
                }
                //So sánh và add thông tin lịch sử;
                if (listtruoc != listsau)
                {
                    string textlisttruoc = "";
                    string textlistsau = "";
                    foreach (var item in listtruoc)
                    {
                        textlisttruoc += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} |";
                    }
                    foreach (var item in listsau)
                    {
                        textlistsau += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} |";
                    }
                    changeText += $"Thay đổi danh sách| TỪ |{textlisttruoc} THÀNH |{textlistsau}";
                }
                //Xóa list cũ
                foreach (var item in listObj)
                {
                    Product product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity - item.Quantity;
                    db.SaveChanges();
                    db.RefundDetails.Remove(item);
                }
                //Thêm list mới
                foreach (var item in model)
                {
                    var refundDetail = new RefundDetail();
                    refundDetail.RefundCode = item.Code;
                    refundDetail.Price = Decimal.Parse(Functions.RemoveCharacters(item.Price));
                    refundDetail.ProductCode = item.ProductCode;
                    refundDetail.Quantity = item.Quantity;
                    refundDetail.UnitID = item.UnitID;
                    Product product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity + item.Quantity;
                    db.RefundDetails.Add(refundDetail);
                    db.SaveChanges();
                }
                SetHistoryRecepit("update", refundReceipt.Code, userName, "phiếu trả hàng", changeText);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int UpdateRefundForStaff(List<ListRefund> model, string userName)
        {
            try
            {
                string codeRefund = model.FirstOrDefault().Code;
                var refund = db.Refunds.Where(x => x.Code == codeRefund).FirstOrDefault();
                if (refund.Status == false)
                {
                    string changeText = "";
                    var obj = model.First();
                    if (model.FirstOrDefault().Note == null)
                    {
                        foreach (var item in model)
                        {
                            item.Note = " ";
                        }
                    }
                    var exportRefund = db.Refunds.Where(x => x.Code == obj.Code).First();
                    if (exportRefund.Note != obj.Note)
                    {
                        changeText += $"Thay đổi ghi chú từ '{exportRefund.Note}' thành '{obj.Note}' | ";
                        exportRefund.Note = obj.Note;
                    }
                    if (exportRefund.CustomerCode != obj.CustomerCode)
                    {
                        changeText += $"Thay đổi tên KH từ '{db.Customers.Where(x => x.CustomerCode == exportRefund.CustomerCode).FirstOrDefault().Name}' thành '{db.Customers.Where(x => x.CustomerCode == obj.CustomerCode).FirstOrDefault().Name}' | ";
                        exportRefund.CustomerCode = obj.CustomerCode;
                    }
                    if (exportRefund.Note != obj.Note)
                    {
                        changeText += $"Thay đổi ghi chú từ '{exportRefund.Note}' thành '{obj.Note}' | ";
                        exportRefund.Note = obj.Note;
                    }
                    if (exportRefund.Time != obj.Time)
                    {
                        changeText += $"Thay đổi thời gian từ '{exportRefund.Time}' thành '{obj.Time}' | ";
                        exportRefund.Time = obj.Time;
                    }
                    if (exportRefund.Status != obj.Status)
                    {
                        changeText += $"Thay đổi trạng thái từ '{GetStatus(exportRefund.Status)}' thành '{GetStatus(obj.Status)}' | ";
                        exportRefund.Status = obj.Status;
                    }
                    var listObj = db.RefundDetails.Where(x => x.RefundCode == obj.Code).ToList();
                    //Thêm list Product trước và sau;
                    var listtruoc = new List<ListProduct>();
                    var listsau = new List<ListProduct>();
                    foreach (var item in listObj)
                    {
                        var product = new ListProduct();
                        product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                        product.Quantity = item.Quantity;
                        product.Price = item.Price;
                        product.Unit = db.Units.Find(item.UnitID).Name;
                        listtruoc.Add(product);
                    }
                    foreach (var item in model)
                    {
                        var product = new ListProduct();
                        product.Name = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                        product.Quantity = item.Quantity;
                        product.Price = Convert.ToDecimal(item.Price);
                        product.Unit = db.Units.Find(item.UnitID).Name;
                        listsau.Add(product);
                    }
                    //So sánh và add thông tin lịch sử;
                    if (listtruoc != listsau)
                    {
                        string textlisttruoc = "";
                        string textlistsau = "";
                        foreach (var item in listtruoc)
                        {
                            textlisttruoc += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} |";
                        }
                        foreach (var item in listsau)
                        {
                            textlistsau += $"Tên: {item.Name}, SL: {item.Quantity}, Giá: {Functions.NumberToMoney(item.Price.ToString())}, ĐVT: {item.Unit} |";
                        }
                        changeText += $"Thay đổi danh sách| TỪ |{textlisttruoc} THÀNH |{textlistsau}";
                    }
                    //Xóa list cũ
                    foreach (var item in listObj)
                    {
                        Product product = new Product();
                        product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                        product.Quantity = product.Quantity + item.Quantity;
                        db.SaveChanges();
                        db.RefundDetails.Remove(item);
                    }
                    //Thêm list mới
                    foreach (var item in model)
                    {
                        var refundDetail = new RefundDetail();
                        refundDetail.RefundCode = item.Code;
                        refundDetail.Price = Decimal.Parse(Functions.RemoveCharacters(item.Price));
                        refundDetail.ProductCode = item.ProductCode;
                        refundDetail.Quantity = item.Quantity;
                        refundDetail.UnitID = item.UnitID;
                        Product product = new Product();
                        product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                        product.Quantity = product.Quantity - item.Quantity;
                        db.RefundDetails.Add(refundDetail);
                        db.SaveChanges();
                    }
                    SetHistoryRecepit("update", refund.Code, userName, "phiếu trả", changeText);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public bool DeleteRefund(long id, string userName)
        {
            try
            {
                var refundRecepit = db.Refunds.Find(id);
                var listDetails = db.RefundDetails.Where(x => x.RefundCode == refundRecepit.Code).ToList();
                foreach (var item in listDetails)
                {
                    item.RefundDetailDelete = true;
                    var product = new Product();
                    product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                    product.Quantity = product.Quantity - item.Quantity;
                    db.SaveChanges();
                }
                SetHistoryRecepit("delete", refundRecepit.Code, userName, "phiếu trả hàng");
                refundRecepit.RefundDelete = true;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteRefundForStaff(long id, string userName)
        {
            try
            {
                var refund = db.Refunds.Find(id);
                if (refund.Status == false)
                {
                    var refundRecepit = db.Refunds.Find(id);
                    var listDetails = db.RefundDetails.Where(x => x.RefundCode == refundRecepit.Code).ToList();
                    foreach (var item in listDetails)
                    {
                        item.RefundDetailDelete = true;
                        var product = new Product();
                        product = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault();
                        product.Quantity = product.Quantity + item.Quantity;
                        db.SaveChanges();
                    }
                    SetHistoryRecepit("delete", refundRecepit.Code, userName, "phiếu trả");
                    refundRecepit.RefundDelete = true;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        public List<RefundModel> GetDataRefund(string code)
        {
            var refund = db.Refunds.Where(x => x.Code == code).FirstOrDefault();
            var reunfds = db.RefundDetails.Where(x => x.RefundCode == code).ToList();
            decimal tongtien = 0;
            List<RefundModel> listRefund = new List<RefundModel>();
            foreach (var item in reunfds)
            {
                tongtien += (item.Quantity * item.Price);
            }
            foreach (var item in reunfds)
            {
                var model = new RefundModel();
                model.CustomerName = db.Customers.Where(x => x.CustomerCode == refund.CustomerCode).FirstOrDefault().Name;
                model.RefundCode = code;
                model.Note = refund.Note;
                model.Price = item.Price;
                model.ProductName = db.Products.Where(x => x.Code == item.ProductCode).FirstOrDefault().Name;
                model.Quantity = item.Quantity;
                model.Staff = db.Users.Find(refund.UserID).Name;
                model.Time = refund.Time.ToString("dd-MM-yyyy HH:mm");
                model.UnitName = db.Units.Find(item.UnitID).Name;
                model.Total = tongtien;
                listRefund.Add(model);
            }
            return listRefund;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Lưu lịch sử
        public void SetHistory(string actionKey, string userName, string subject, string detail)
        {
            string text = $"'{userName}' vừa ";
            switch (actionKey)
            {
                case "update":
                    text += $"cập nhật '{subject}' ";
                    break;
                case "insert":
                    text += $"thêm mới '{subject}' ";
                    break;
                case "delete":
                    text += $"xóa '{subject}' ";
                    break;
            }
            text += detail;
            var history = new History();
            history.ActionKey = actionKey;
            history.Date = DateTime.Now;
            history.Text = text;
            db.Histories.Add(history);
            db.SaveChanges();
        }
        public void SetHistoryRecepit(string actionKey, string receiptCode, string userName, string objectName, string detail = "")
        {
            string text = $"'{userName}' vừa ";
            switch (actionKey)
            {
                case "update":
                    text += $"cập nhật '{objectName}' | {detail}";
                    break;
                case "insert":
                    text += $"thêm mới '{objectName}' ";
                    break;
                case "delete":
                    text += $"xóa '{objectName}' ";
                    break;
            }
            text += $"với mã phiếu '{receiptCode}'";
            var history = new History();
            history.ActionKey = actionKey;
            history.Date = DateTime.Now;
            history.Text = text;
            history.ReceiptCode = receiptCode;
            history.Object = objectName;
            history.UserName = userName;
            db.Histories.Add(history);
            db.SaveChanges();
        }
        public IEnumerable<History> GetHistory(DateTime? time, string actionKey, int page, int pageSize)
        {
            IQueryable<History> model = db.Histories;
            if (!string.IsNullOrEmpty(actionKey) && time == null)
            {
                model = model.Where(x => x.ActionKey == actionKey && x.ReceiptCode == null);
            }
            else if (string.IsNullOrEmpty(actionKey) && time != null)
            {
                model = model.Where(x => x.Date.Day == time.Value.Day && x.Date.Month == time.Value.Month && x.Date.Year == time.Value.Year && x.ReceiptCode == null);
            }
            else if (!string.IsNullOrEmpty(actionKey) && time != null)
            {
                model = model.Where(x => x.ActionKey == actionKey && x.Date.Day == time.Value.Day && x.Date.Month == time.Value.Month && x.Date.Year == time.Value.Year && x.ReceiptCode == null);
            }
            else
            {
                model = model.Where(x => x.ReceiptCode == null);
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public IEnumerable<History> GetHistoryReceipt(DateTime? time, string actionKey, int page, int pageSize)
        {
            IQueryable<History> model = db.Histories;
            if (!string.IsNullOrEmpty(actionKey) && time == null)
            {
                model = model.Where(x => x.ReceiptCode != null && x.ActionKey == actionKey && x.Object != null);
            }
            else if (string.IsNullOrEmpty(actionKey) && time != null)
            {
                model = model.Where(x => x.ReceiptCode != null && x.Date.Day == time.Value.Day && x.Date.Month == time.Value.Month && x.Date.Year == time.Value.Year && x.Object != null);
            }
            else if (!string.IsNullOrEmpty(actionKey) && time != null)
            {
                model = model.Where(x => x.ReceiptCode != null && x.ActionKey == actionKey && x.Date.Day == time.Value.Day && x.Date.Month == time.Value.Month && x.Date.Year == time.Value.Year && x.Object != null);
            }
            else
            {
                model = model.Where(x => x.ReceiptCode != null);
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Nhân viên
        public IEnumerable<ExportViewModel> ListAllReceiptExportOnPagedlist(string searchString, DateTime? dateExport, string userName, bool status, int page, int pageSize)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                searchString = "";
            }
            else
            {
                searchString = searchString.Trim();
            }
            if (dateExport.HasValue)
            {
                var result = (from export in db.Exports
                             join customer in db.Customers on export.CustomerCode equals customer.CustomerCode
                             join supply in db.ExportDetails on export.Code equals supply.ExportCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on export.UserID equals users.ID
                             where users.UserName == userName && export.Note.Contains(searchString) && customer.Name.Contains(searchString) && product.Name.Contains(searchString) && export.Time.Year == dateExport.Value.Year && export.Time.Month == dateExport.Value.Month && export.Time.Day == dateExport.Value.Day && export.ExportDelete == status
                             select new ExportViewModel()
                             {
                                 Code = export.Code,
                                 CustomerName = customer.Name,
                                 Note = export.Note,
                                 Time = export.Time,
                                 Delivery = export.Delivery,
                                 ExportDelete = export.ExportDelete,
                                 NameUser = users.Name,
                                 Status = export.Status
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);

            }
            else
            {
                var result = (from export in db.Exports
                             join customer in db.Customers on export.CustomerCode equals customer.CustomerCode
                             join supply in db.ExportDetails on export.Code equals supply.ExportCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on export.UserID equals users.ID
                             where users.UserName == userName && export.Note.Contains(searchString) && customer.Name.Contains(searchString) && product.Name.Contains(searchString) && export.ExportDelete == status
                             select new ExportViewModel()
                             {
                                 Code = export.Code,
                                 CustomerName = customer.Name,
                                 Note = export.Note,
                                 Time = export.Time,
                                 Delivery = export.Delivery,
                                 ExportDelete = export.ExportDelete,
                                 NameUser = users.Name,
                                 Status = export.Status
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);

            }
        }
        public IEnumerable<RefundViewModel> ListAllReceiptRefundOnPagedlist(string searchString, DateTime? dateRefund, string userName, bool status, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
            }
            else
            {
                searchString = "";
            }
            if (dateRefund.HasValue)
            {
                var result = (from refund in db.Refunds
                             join customer in db.Customers on refund.CustomerCode equals customer.CustomerCode
                             join supply in db.RefundDetails on refund.Code equals supply.RefundCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on refund.UserID equals users.ID
                             where refund.Note.Contains(searchString) && customer.Name.Contains(searchString) && users.Name.Contains(searchString) && product.Name.Contains(searchString) && refund.Time.Year == dateRefund.Value.Year && refund.Time.Month == dateRefund.Value.Month && refund.Time.Day == dateRefund.Value.Day && refund.RefundDelete == status && users.UserName == userName
                             group new { refund, customer, supply, product, users } by new { refund.Code } into grp
                             select new RefundViewModel()
                             {
                                 Code = grp.Key.Code,
                                 CustomerName = grp.FirstOrDefault().customer.Name,
                                 NameUser = grp.FirstOrDefault().users.Name,
                                 Note = grp.FirstOrDefault().refund.Note,
                                 Time = grp.FirstOrDefault().refund.Time,
                                 RefundDelete = grp.FirstOrDefault().refund.RefundDelete,
                                 Status = grp.FirstOrDefault().refund.Status,
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
            else
            {
                var result = (from refund in db.Refunds
                             join customer in db.Customers on refund.CustomerCode equals customer.CustomerCode
                             join supply in db.RefundDetails on refund.Code equals supply.RefundCode
                             join product in db.Products on supply.ProductCode equals product.Code
                             join users in db.Users on refund.UserID equals users.ID
                             where refund.Note.Contains(searchString) && customer.Name.Contains(searchString) && users.Name.Contains(searchString) & product.Name.Contains(searchString) && refund.RefundDelete == status && users.UserName == userName                   
                             select new RefundViewModel()
                             {
                                 Code = refund.Code,
                                 CustomerName = customer.Name,
                                 NameUser = users.Name,
                                 Note = refund.Note,
                                 Time = refund.Time,
                                 RefundDelete = refund.RefundDelete,
                                 Status = refund.Status,
                             }).Distinct();
                return result.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
            }
        }
    }
}