using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Utilities.Static
{
    public class ExcelColumnNames
    {
        public static List<TableColumn> GetColumns(IEnumerable<(string ColumnName, string PropertyName)> columnsProperties)
        {
            var columns = new List<TableColumn>();

            foreach ( var (ColumnName, PropertyName) in columnsProperties)
            {
                var column = new TableColumn() 
                {
                    Label = ColumnName,
                    PropertyName = PropertyName
                };
                columns.Add(column);
            }
            return columns;
        }

        #region ColumnsCategories
        public static List<(string ColumnName, string PropertyName)> GetColumnsCategories()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE","Name"),
                ("DESCRIPCION", "Description"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateCategory")
            };
            return columnsProperties;
        }
        #endregion

        #region ColumnsProviders
        public static List<(string ColumnName, string PropertyName)> GetColumnsProviders()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE","Name"),
                ("EMAIL", "Email"),
                ("TIPO DE DOCUMENTO", "DocumentType"),
                ("N° DE DOCUMENTO", "DocumentNumber"),
                ("DIRECCIÓN", "Address"),
                ("TELÉFONO", "phone"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateProvider")
            };
            return columnsProperties;
        }
        #endregion

        #region ColumnsWarehouse
        public static List<(string ColumnName, string PropertyName)> GetColumnsWarehouses()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE","Name"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateWarehouse"),
            };
            return columnsProperties;
        }
        #endregion

        #region ColumnsProducts
        public static List<(string ColumnName, string PropertyName)> GetColumnsProducts()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("CÓDIGO","Code"),
                ("NOMBRE", "Name"),
                ("STOCK MÍNIMO", "StockMin"),
                ("STOCK MÁXIMO", "StockMax"),
                ("PRECIO DE VENTA", "UnitSalePrice"),
                ("CATEGORÍA", "Category"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateProduct")
            };
            return columnsProperties;
        }
        #endregion       

        #region GetColumnsPurcharse
        public static List<(string ColumnName, string PropertyName)> GetColumnsPurcharse()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("PROVEEDOR","Provider"),
                ("ALMACÉN", "Warehouse"),
                ("MONTO TOTAL", "TotalAmount"),
                ("FECHA DE COMPRA", "DateOffPurcharse"),
            };
            return columnsProperties;
        }
        #endregion

        #region ColumnsClients
        public static List<(string ColumnName, string PropertyName)> GetColumnsClients()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE", "Name"),
                ("EMAIL", "Email"),
                ("TIPO DE DOCUMENTO", "DocumentType"),
                ("N° DE DOCUMENTO", "DocumentNumber"),
                ("DIRECCION", "Address"),
                ("TELEFONO", "phone"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateClient")
            };
            return columnsProperties;
        }
        #endregion
    }
}
