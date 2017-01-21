using System.Collections.Generic;

namespace PTC.Data
{
    public class TrainingProductViewModel
    {
        public string EventCommand { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        public TrainingProductViewModel()
        {
            Init();

            Products = new List<TrainingProduct>();
            ResetSearch();
        }

        private void Init()
        {
            EventCommand = "List";

            ListMode();
        }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    AddMode();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                case "save":
                    break;

                default:
                    break;
            }
        }

        private void ListMode()
        {
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;
        }

        private void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        private void Get()
        {
            var mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
        }
    }
}
