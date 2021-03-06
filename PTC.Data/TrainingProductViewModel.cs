﻿using PTC.Common;
using System;
using System.Collections.Generic;

namespace PTC.Data
{
    public class TrainingProductViewModel : ViewModelBase
    {
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public TrainingProduct Entity { get; set; }
        public TrainingProductViewModel() : base()
        {
        }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            Entity = new TrainingProduct();
            EventArgument = string.Empty;
            ResetSearch();
            base.Init();
        }

        protected override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "paul":
                    break;

                default:
                    break;
            }

            base.HandleRequest();
        }

        protected override void Edit()
        {
            var mgr = new TrainingProductManager();

            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            base.Edit();
        }

        protected override void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct()
            {
                IntroductionDate = DateTime.Now,
                Url = "http://",
                Price = 0m,
            };

            base.Add();
        }

        protected override void Save()
        {
            var mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;

            base.Save();
        }

        protected override void Delete()
        {
            var mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();

            base.Delete();
        }

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
            base.ResetSearch();
        }

        protected override void Get()
        {
            var mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);

            base.Get();
        }
    }
}