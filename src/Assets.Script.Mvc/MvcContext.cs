using System;
using System.Collections.Generic;

namespace Assets.Script.Mvc
{
	public class MvcContext
	{
		public IEventDispatcher EventDispatcher = new MvcEventDispatcher();

		private Dictionary<string, IView> registeredView = new Dictionary<string, IView>();

		private Dictionary<string, IModel> registeredModel = new Dictionary<string, IModel>();

		private Dictionary<Type, ICommand> singleUseCommandAgents = new Dictionary<Type, ICommand>();

		public void RegisterView(string name, IView view)
		{
			this.registeredView.Add(name, view);
			view.Context = this;
			view.EventDispatcher = this.EventDispatcher;
			view.OnRegister();
		}

		public void RegisterView<T>(IView view) where T : IView
		{
			this.registeredView.Add(typeof(T).FullName, view);
			view.Context = this;
			view.EventDispatcher = this.EventDispatcher;
			view.OnRegister();
		}

		public IView GetView(string name)
		{
			IView result;
			this.registeredView.TryGetValue(name, out result);
			return result;
		}

		public T GetView<T>() where T : class, IView
		{
			IView view;
			this.registeredView.TryGetValue(typeof(T).FullName, out view);
			return view as T;
		}

		public void UnregisterView(string name)
		{
			IView view;
			bool flag = this.registeredView.TryGetValue(name, out view);
			if (flag)
			{
				view.Context = null;
				view.EventDispatcher = null;
				this.registeredView.Remove(name);
				view.OnUnRegister();
			}
		}

		public void UnregisterView<T>()
		{
			string fullName = typeof(T).FullName;
			IView view;
			bool flag = this.registeredView.TryGetValue(fullName, out view);
			if (flag)
			{
				view.Context = null;
				view.EventDispatcher = null;
				this.registeredView.Remove(fullName);
				view.OnUnRegister();
			}
		}

		public void RegisterModel(string name, IModel model)
		{
			this.registeredModel.Add(name, model);
			model.Context = this;
			model.EventDispatcher = this.EventDispatcher;
			model.OnRegister();
		}

		public void RegisterModel<T>(IModel model) where T : IModel
		{
			this.registeredModel.Add(typeof(T).FullName, model);
			model.Context = this;
			model.EventDispatcher = this.EventDispatcher;
			model.OnRegister();
		}

		public IModel GetModel(string name)
		{
			IModel result;
			this.registeredModel.TryGetValue(name, out result);
			return result;
		}

		public T GetModel<T>() where T : class, IModel
		{
			IModel model;
			this.registeredModel.TryGetValue(typeof(T).FullName, out model);
			return model as T;
		}

		public void UnregisterModel(string name)
		{
			IModel model;
			bool flag = this.registeredModel.TryGetValue(name, out model);
			if (flag)
			{
				model.Context = null;
				model.EventDispatcher = null;
				this.registeredModel.Remove(name);
				model.OnUnRegister();
			}
		}

		public void UnregisterModel<T>()
		{
			string fullName = typeof(T).FullName;
			IModel model;
			bool flag = this.registeredModel.TryGetValue(fullName, out model);
			if (flag)
			{
				model.Context = null;
				model.EventDispatcher = null;
				this.registeredModel.Remove(fullName);
				model.OnUnRegister();
			}
		}

		public void RegisterCommand(string eventName, ICommand command)
		{
			command.Context = this;
			command.EventDispatcher = this.EventDispatcher;
			this.EventDispatcher.AddEventListener(eventName, new Action<IEvent>(command.Execute));
			command.OnRegister();
		}

		public void UnregisterCommand(string eventName, ICommand command)
		{
			this.EventDispatcher.RemoveEventListener(eventName, new Action<IEvent>(command.Execute));
			command.OnUnRegister();
		}

		public void RegisterSingleUseCommand<T>(string eventName) where T : ICommand, new()
		{
			SingleUseCommandAgent<T> singleUseCommandAgent = new SingleUseCommandAgent<T>();
			this.singleUseCommandAgents.Add(typeof(T), singleUseCommandAgent);
			this.RegisterCommand(eventName, singleUseCommandAgent);
		}

		public void UnregisterSingleUseCommand<T>(string eventName) where T : ICommand, new()
		{
			Type typeFromHandle = typeof(T);
			ICommand command = this.singleUseCommandAgents[typeof(T)];
			this.singleUseCommandAgents.Remove(typeFromHandle);
			this.UnregisterCommand(eventName, command);
		}
	}
}
