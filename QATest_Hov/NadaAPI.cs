using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;

namespace QATest_Hov
{
	public class NadaAPI						//Inbox email fron NADA
	{
		[JsonProperty("uid")]
		public string UserID;

		[JsonProperty("s")]
		public string subject;

		[JsonProperty("f")]
		public string from;

		[JsonProperty("ib")]
		public string email;

		public string getMessageID()
		{
			return UserID;
		}

		public string getSubject()
		{
			return subject;
		}

		public string getFrom()
		{
			return from;
		}

		public string getEmail()
		{
			return email;
		}

		/*{"last":1624078675,
		"total":"29972767",
		"msgs":[
			{"uid":"qxxCtdOY8kpBySYauLGHNOeupJm6Ng",
			"ib":"gyxiguka@boximail.com",
			"f":"REITScreener",
			"s":"Welcome to REITScreener..."
			,"d":false,
			"at":[],
			"r":1624078675,"fe":"noreply@reitscreener.com","rf":"Today - 4:57 am","ii":"R","av":"#c0392b"}]} */
	}

	 public class NadaEmailService
	{
		private const string NADA_EMAIL_DOMAIN = "@getnada.com";
		private const string EMAIL_ID_ROUTE_PARAM = "email-id";
		private const string MESSAGE_ID_ROUTE_PARAM = "message-id";
		private const string INBOX_MESSAGE_KEY_NAME = "msgs";
		private const string NADA_EMAIL_INBOX_API = "https://getnada.com/api/v1/inboxes/{email-id}";
		private const string NADA_EMAIL_MESSAGE_API = "https://getnada.com/api/v1/messages/{message-id}";
		private const int EMAIL_CHARS_LENGTH = 10;
		//private static readonly ObjectMapper MAPPER = new ObjectMapper();

		private string emailId;

		NadaEmailService jsonObj = new NadaEmailService();

		private string randomeEmailId()
		{
			emailId = ("sampletest" + NADA_EMAIL_DOMAIN);
			return emailId;
		}
		/*
		public virtual IList<NadaAPI> Inbox
		{
			get
			{
				string msgs = Unirest.get(NADA_EMAIL_INBOX_API).routeParam(EMAIL_ID_ROUTE_PARAM, randomeEmailId).asJson().getBody().getObject().getJSONArray(INBOX_MESSAGE_KEY_NAME).ToString();
				return MAPPER.readValue(msgs, new TypeReferenceAnonymousInnerClass());
			}
		}

		private class TypeReferenceAnonymousInnerClass : TypeReference<IList<InboxEmail>>
		{
			private readonly NadaEMailService outerInstance;

		}

		public virtual EmailMessage getMessageById(in string messageId)
		{
			string msgs = Unirest.get(NADA_EMAIL_MESSAGE_API).routeParam(MESSAGE_ID_ROUTE_PARAM, messageId).asJson().getBody().getObject().ToString();
			return MAPPER.readValue(msgs, typeof(EmailMessage));
		} */
	}
}
