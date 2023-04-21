using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using DTO.Cache;
using PresentationLayer.Cache;

namespace BusinessLogicLayer
{
    public class BLL_DataProduct
    {
        private DataProduct dataProduct = new DataProduct();

        //Hiện tất cả thông tin sản phẩm
        public DataTable dataShowProduct()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataProduct.tableDataProduct();
            return dataTable;
        }
        //hiện danh sách loại sản phẩm
        public DataTable ListTypeProduct()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataProduct.ListType();
            return dataTable;
        }
        // danh sách sản phẩm giảm giá
        public DataTable SaleProduct()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataProduct.tableDataProductSale();
            return dataTable;
        }
        //danh sách tất cả sản phẩm
        public DataTable AllProduct()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataProduct.tableDataProductAll();
            return dataTable;
        }
        //danh sách đồ ăn
        public DataTable FoodProduct()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataProduct.tableDataProductFood();
            return dataTable;
        }
        //danh sách đồ uống
        public DataTable DrinkProduct()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataProduct.tableDataProductDrink();
            return dataTable;
        }

        //
        public DataTable SellingProd()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataProduct.tableDataProductSeling();
            return dataTable;
        }

        public DataTable SearchProd(string keyword)
        {
            DataTable dataTable = new DataTable();
            dataTable = dataProduct.Search(keyword);
            return dataTable;
        }

        public DTO_Product searchProductBill(string keyword)
        {
            DTO_Product k = new DTO_Product();
            k=dataProduct.searchProductforBill(keyword);
            return k;
        }
        public string GetIDProductBill(string namepro)
        {
            DTO_Product dtt = new DTO_Product();
           string masp = dataProduct.GetIdProduct(namepro);
            return masp;
        }

        public void IncreaseProd(string masp,decimal soluong)
        {
            dataProduct.IncreaseProd(masp, soluong);


        }
        public void DecreaseProd(string masp,decimal soluong )
        {

            dataProduct.DecreaseProd(masp, soluong);
           


        }

        //thêm sản phẩm
        public void InsertProduct(DTO_Product ex)
        {
            dataProduct.Insert(ex);
        }
        //sửa sản phẩm
        public void EditProduct(DTO_Product ex)
        {
            dataProduct.Edita(ex);
        }
        //Xóa sản phẩm
        public void DeletedProduct(DTO_Product ex)
        {
            dataProduct.Deleted(ex);
        }
       
    }
}
