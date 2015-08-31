﻿namespace StockSharp.Messages
{
	using System;
	using System.Runtime.Serialization;

	using Ecng.Common;

	/// <summary>
	/// Сообщение, содержащее информацию для перерегистрации заявки.
	/// </summary>
	[DataContract]
	[Serializable]
	public class OrderReplaceMessage : OrderRegisterMessage
	{
		/// <summary>
		/// Идентификатор перерегистрируемой заявки.
		/// </summary>
		[DataMember]
		public long? OldOrderId { get; set; }

		/// <summary>
		/// Идентификатор перерегистрируемой заявки (ввиде строки, если электронная площадка не использует числовое представление идентификатора заявки).
		/// </summary>
		[DataMember]
		public string OldOrderStringId { get; set; }

		/// <summary>
		/// Идентификатор транзакции перерегистрируемой заявки.
		/// </summary>
		[DataMember]
		public long OldTransactionId { get; set; }

		/// <summary>
		/// Создать <see cref="OrderReplaceMessage"/>.
		/// </summary>
		public OrderReplaceMessage()
			: base(MessageTypes.OrderReplace)
		{
		}

		/// <summary>
		/// Создать копию <see cref="OrderReplaceMessage"/>.
		/// </summary>
		/// <returns>Копия.</returns>
		public override Message Clone()
		{
			var clone = new OrderReplaceMessage
			{
				Comment = Comment,
				Condition = Condition,
				TillDate = TillDate,
				OrderType = OrderType,
				PortfolioName = PortfolioName,
				Price = Price,
				RepoInfo = RepoInfo,
				RpsInfo = RpsInfo,
				SecurityId = SecurityId,
				Side = Side,
				TimeInForce = TimeInForce,
				TransactionId = TransactionId,
				VisibleVolume = VisibleVolume,
				Volume = Volume,
				OldOrderId = OldOrderId,
				OldOrderStringId = OldOrderStringId,
				OldTransactionId = OldTransactionId,
				UserOrderId = UserOrderId,
				ClientCode = ClientCode,
				BrokerCode = BrokerCode,
			};

			CopyTo(clone);

			return clone;
		}

		/// <summary>
		/// Получить строковое представление.
		/// </summary>
		/// <returns>Строковое представление.</returns>
		public override string ToString()
		{
			return base.ToString() + ",OldTransId={0},OldOrdId={1},NewTransId={2}".Put(OldTransactionId, OldOrderId, TransactionId);
		}
	}
}