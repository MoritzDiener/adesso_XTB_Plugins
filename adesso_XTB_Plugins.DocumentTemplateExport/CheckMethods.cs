using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    public static class CheckMethods
    {
        public static bool DoesGridviewContainGuid(DataGridView dgv, string searchField, Guid id)
        {
            var result = false;
            if (id != Guid.Empty)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    var idFromRow = new Guid(row.Cells[searchField].Value.ToString());
                    if (idFromRow == id)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool DoesGridviewContainString(DataGridView dgv, string searchField)
        {
            var result = false;

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (string.IsNullOrEmpty(row.Cells[searchField].Value.ToString()))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
