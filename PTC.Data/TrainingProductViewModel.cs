using System.Collections.Generic;

namespace PTC.Data
{
    public class TrainingProductViewModel
    {
        public string EventCommand { get; set; }
        public List<TrainingProduct> Products { get; set; }

        public TrainingProductViewModel()
        {
            Products = new List<TrainingProduct>();
            EventCommand = "list";
        }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                    Get();
                    break;

                default:
                    break;
            }
        }

        private void Get()
        {
            var mgr = new TrainingProductManager();
            Products = mgr.Get();
        }
    }
}
