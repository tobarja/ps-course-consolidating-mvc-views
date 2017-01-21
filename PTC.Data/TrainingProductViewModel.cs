using System.Collections.Generic;

namespace PTC.Data
{
    public class TrainingProductViewModel
    {
        public string EventCommand { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }

        public TrainingProductViewModel()
        {
            Products = new List<TrainingProduct>();
            EventCommand = "list";
            ResetSearch();
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

                default:
                    break;
            }
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
