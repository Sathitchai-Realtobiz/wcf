﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


using System;
using System.ServiceModel;

namespace WcfService
{
    [MessageContract(IsWrapped = false, WrapperName = "CustomWrapperName", WrapperNamespace = "http://www.contoso.com")]
    internal class ReplyBankingDataNotWrapped
    {
        [MessageBodyMember(Order = 1, Name = "Date_of_Request")]
        public DateTime transactionDate;
        [MessageBodyMember(Name = "Customer_Name", Namespace = "http://www.contoso.com", Order = 3)]
        public string accountName;
        [MessageBodyMember(Order = 2, Name = "Transaction_Amount")]
        public int amount;
    }

    [MessageContract(IsWrapped = true, WrapperName = "CustomWrapperName", WrapperNamespace = "http://www.contoso.com")]
    internal class ReplyBankingDataWithMessageHeader
    {
        [MessageBodyMember(Order = 1, Name = "Date_of_Request")]
        public DateTime transactionDate;
        [MessageBodyMember(Name = "Customer_Name", Namespace = "http://www.contoso.com", Order = 3)]
        public string accountName;
        [MessageBodyMember(Order = 2, Name = "Transaction_Amount")]
        public int amount;
        [MessageHeader(Name = "OutOfBandData", Namespace = "http://www.contoso.com", MustUnderstand = true)]
        public string extraValues;
    }

    [MessageContract(IsWrapped = true, WrapperName = "CustomWrapperName", WrapperNamespace = "http://www.contoso.com")]
    public class ReplyBankingDataWithMessageHeaderNotNecessaryUnderstood
    {
        [MessageBodyMember(Order = 1, Name = "Date_of_Request")]
        public DateTime transactionDate;
        [MessageBodyMember(Name = "Customer_Name", Namespace = "http://www.contoso.com", Order = 3)]
        public string accountName;
        [MessageBodyMember(Order = 2, Name = "Transaction_Amount")]
        public int amount;
        [MessageHeader(Name = "OutOfBandData", Namespace = "http://www.contoso.com", MustUnderstand = false)]
        public string extraValues;
    }
}
