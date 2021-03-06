﻿using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.Base;
using Tesla.ViewModel.MainTabs;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class ControlViewModel : BaseViewModel
    {

        public ControlViewModel(IAuthModel authModel, IControlModel model, IExrinContainer exrinContainer) :
            base(authModel, exrinContainer, new ControlVisualState(model))
        {
            Model = model;
        }

        // Model
        public IControlModel Model { get; set; }

        // TODO: took a little while to find out that the model wasn't been set, look to enforce it.
        // TODO: Wire up the Honk to status on Control screen
        // Failed Status (Dialog or screen?) - prob dialog because its an action we expect an immediate result

        // Find Car
        // Climate

        // View Commands      
        public IRelayCommand HonkCommand
        {
            get
            {
                return GetCommand(() =>
                {
                    return Execution.ViewModelExecute(new HonkViewModelExecute(Model));
                });
            }
        }

        public IRelayCommand FlashCommand
        {
            get
            {
                return GetCommand(() =>
                {
                    return Execution.ViewModelExecute(new FlashViewModelExecute(Model));
                });
            }
        }
        
    }
}
