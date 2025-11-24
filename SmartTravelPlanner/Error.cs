using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTravelPlanner
{
    static class Error
    {
        public const string ERROR_TITLE = "Error";
        public const string EMPTY_TRAV_OR_DEST_ERROR = "Empty traveler or destination field.";
        public const string DEST_ERROR = "Destination not reachable or not in map.";
        public const string MAP_ERROR = "Map file not found or invalid format.";
        public const string JSON_PARSE_ERROR = "Invalid \'.json\' file during loading.";

        public static void HandleError(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
