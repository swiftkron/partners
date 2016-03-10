var sortedSubscriptionItems = subscription.RatePlans.OrderByDescending(i => i.RatePlanName).GroupBy(i => i.ProductRatePlanId);

            //Act! Pro discounts don't mean anything on a Perpetual License model, so no need to surface
            return (from groupedItems in sortedSubscriptionItems
                    let subscriptionItem = groupedItems.FirstOrDefault()
                    where subscriptionItem != null && subscriptionItem.ProductName != "Act! Pro Volume Discounts"
                    let quantity = (from item in groupedItems
                                    where item.RatePlanCharges != null
                                    select item.RatePlanCharges.FirstOrDefault()
                                        into charge
                                        select int.Parse(charge != null ? charge.Quantity : "0")).Sum()
                    select new InvoiceItemDetails(quantity, subscriptionItem.RatePlanName, 0)).ToList();

var sortedInvoiceItems = this.Preview.InvoiceItems.OrderByDescending(i => double.Parse(i.ChargeAmount)).GroupBy(i => i.ProductRatePlanChargeId);

            foreach(var groupedItems in sortedInvoiceItems)
            {
                var invoiceItem = groupedItems.FirstOrDefault();
                if(invoiceItem == null)
                {
                    continue;
                }

                double price = 0;
                var quantity = 0;
                foreach(var item in groupedItems)
                {
                    var itemCharge = double.Parse(item.ChargeAmount);
                    price += itemCharge;

                    if(itemCharge < 0)
                    {
                        quantity -= int.Parse(item.Quantity);
                    }
                    else
                    {
                        quantity += int.Parse(item.Quantity);
                    }
                }

                //discounts are all over the map. just set quantity to 1
                if(invoiceItem.ProductName == "Act! Volume Discounts")
                {
                    quantity = 0;
                }

                details.Add(new InvoiceItemDetails(quantity, invoiceItem.ChargeDescription, price));
            }