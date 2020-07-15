using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using XamarinDemo.Models;

namespace XamarinDemo.Data
{
    public class NetworkingHelper
    {
        public ResponseObject responseObject;

        private static NetworkingHelper _Instance;
        public static NetworkingHelper Instance
        {
            get
            {
                if (_Instance == null) {
                    _Instance = new NetworkingHelper();
                }
                return _Instance;
            }
        }

        private NetworkingHelper() { }

        public async Task<List<CellViewModel>> FetchData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.mystrength.com/config?useNewFormat=true");
            var content = await response.Content.ReadAsStringAsync();

            return ParseResponse(content);
        }

        private List<CellViewModel> ParseResponse(string response)
        {
            List<CellViewModel> tableViewCells = new List<CellViewModel>();
            responseObject = JsonConvert.DeserializeObject<ResponseObject>(response);

            foreach (var property in responseObject.GetType().GetRuntimeProperties())
            {
                tableViewCells.Add(MapToCellViewModel(property.Name, property.GetValue(responseObject, null).ToString()));
            }

            return tableViewCells;
        }

        private CellViewModel MapToCellViewModel(string title, string subtitle)
        {
            if (subtitle.Contains("XamarinDemo.Models"))
            {
                subtitle = ". . .";
                return new CellViewModel(title, subtitle, true);

            }
            return new CellViewModel(title, subtitle, false);
        }

        public List<CellViewModel> FetchChildTableViewData(string parent, string clientType)
        {
            List<CellViewModel> tableItems;

            if (parent.Equals("LoginModes"))
            {
                tableItems = MapLoginModesData();
            }
            else if (parent.Equals("Clients"))
            {
                tableItems = MapClientTableViewData();
            }
            else if (parent.Equals("Web") || parent.Equals("Android") || parent.Equals("Ios"))
            {
                tableItems = MapClientChildTableViewData(parent);
            }
            else if (parent.Equals("FeatureFlags"))
            {
                tableItems = MapFeatureFlagsTableViewData(clientType);
            }
            else if (parent.Equals("ClientActions"))
            {
                tableItems = MapClientActionsTableViewData(clientType);
            }
            else
            {
                tableItems = new List<CellViewModel>();
            }

            return tableItems;
        }

        // Child view controller table mappings

        public List<CellViewModel> MapLoginModesData()
        {
            List<CellViewModel> tableViewCells = new List<CellViewModel>();

            foreach (var organization in responseObject.LoginModes.Organizations)
            {
                foreach (var property in organization.GetType().GetRuntimeProperties())
                {
                    tableViewCells.Add(MapToCellViewModel(property.Name, property.GetValue(organization, null).ToString()));
                }
            }

            return tableViewCells;
        }

        public List<CellViewModel> MapClientTableViewData()
        {
            List<CellViewModel> tableViewCells = new List<CellViewModel>();

            foreach (var client in responseObject.Clients.GetType().GetRuntimeProperties())
            {
                tableViewCells.Add(MapToCellViewModel(client.Name, client.GetValue(responseObject.Clients, null).ToString()));
            }

            return tableViewCells;
        }

        public List<CellViewModel> MapClientChildTableViewData(string parent)
        {
            List<CellViewModel> tableViewCells = new List<CellViewModel>();

            if (parent.Equals("Web"))
            {
                foreach (var child in responseObject.Clients.Web.GetType().GetRuntimeProperties())
                {
                    if (child.GetValue(responseObject.Clients.Web, null) == null)
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, "null"));
                    }
                    else if (child.Name == "Messages")
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, responseObject.Clients.Web.Messages.Count.ToString()));
                    }
                    else
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, child.GetValue(responseObject.Clients.Web, null).ToString()));
                    }
                }
            }

            if (parent.Equals("Android"))
            {
                foreach (var child in responseObject.Clients.Android.GetType().GetRuntimeProperties())
                {
                    if (child.GetValue(responseObject.Clients.Android, null) == null)
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, "null"));
                    }
                    else if (child.Name == "Messages")
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, responseObject.Clients.Android.Messages.Count.ToString()));
                    }
                    else
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, child.GetValue(responseObject.Clients.Android, null).ToString()));
                    }
                }
            }

            if (parent.Equals("Ios"))
            {
                foreach (var child in responseObject.Clients.Ios.GetType().GetRuntimeProperties())
                {
                    if (child.GetValue(responseObject.Clients.Ios, null) == null)
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, "null"));
                    }
                    else if (child.Name == "Messages")
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, responseObject.Clients.Ios.Messages.Count.ToString()));
                    }
                    else
                    {
                        tableViewCells.Add(MapToCellViewModel(child.Name, child.GetValue(responseObject.Clients.Ios, null).ToString()));
                    }
                }
            }

            return tableViewCells;
        }

        public List<CellViewModel> MapFeatureFlagsTableViewData(string parent)
        {
            List<CellViewModel> tableViewCells = new List<CellViewModel>();

            if (parent.Equals("Web"))
            {
                foreach (var property in responseObject.Clients.Web.FeatureFlags)
                {
                    tableViewCells.Add(MapToCellViewModel(property.Key, property.Value.ToString()));
                }
            }

            if (parent.Equals("Android"))
            {
                foreach (var property in responseObject.Clients.Android.FeatureFlags)
                {
                    tableViewCells.Add(MapToCellViewModel(property.Key, property.Value.ToString()));
                }
            }

            if (parent.Equals("Ios"))
            {
                foreach (var property in responseObject.Clients.Ios.FeatureFlags)
                {
                    tableViewCells.Add(MapToCellViewModel(property.Key, property.Value.ToString()));
                }
            }

            return tableViewCells;
        }

        public List<CellViewModel> MapClientActionsTableViewData(string parent)
        {
            List<CellViewModel> tableViewCells = new List<CellViewModel>();

            if (parent.Equals("Web"))
            {
                foreach (var property in responseObject.Clients.Web.ClientActions.GetType().GetRuntimeProperties())
                {
                    tableViewCells.Add(MapToCellViewModel(property.Name, property.GetValue(responseObject.Clients.Web.ClientActions, null).ToString()));
                }
            }

            if (parent.Equals("Android"))
            {
                foreach (var property in responseObject.Clients.Android.ClientActions.GetType().GetRuntimeProperties())
                {
                    tableViewCells.Add(MapToCellViewModel(property.Name, property.GetValue(responseObject.Clients.Android.ClientActions, null).ToString()));
                }
            }

            if (parent.Equals("Ios"))
            {
                foreach (var property in responseObject.Clients.Ios.ClientActions.GetType().GetRuntimeProperties())
                {
                    tableViewCells.Add(MapToCellViewModel(property.Name, property.GetValue(responseObject.Clients.Ios.ClientActions, null).ToString()));
                }
            }

            return tableViewCells;
        }
    }
}
