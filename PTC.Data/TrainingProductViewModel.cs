using System;
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
        public TrainingProduct Entity { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }

        public TrainingProductViewModel()
        {
            Init();

            Products = new List<TrainingProduct>();
            Entity = new TrainingProduct();
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
                    Add();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                default:
                    break;
            }
        }

        private void ListMode()
        {
            IsValid = true;
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }

        private void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }

        private void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct()
            {
                IntroductionDate = DateTime.Now,
                Url = "http://",
                Price = 0m,
            };

            AddMode();
        }

        private void Save()
        {
            if (IsValid)
            {
                if (Mode == "Add")
                {
                    //Add data to db here
                }
            }
            else
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
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
