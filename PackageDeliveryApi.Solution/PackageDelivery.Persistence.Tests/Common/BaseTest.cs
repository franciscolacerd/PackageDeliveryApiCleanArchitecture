﻿using FluentAssertions;
using PackageDelivery.Application.Contracts.Persistence;
using PackageDelivery.Application.Extensions;
using PackageDelivery.Domain;

namespace PackageDelivery.Persistence.Tests.Common
{
    public class BaseTest
    {
        protected IUnitOfWork _unitOfWork;

        private Delivery _delivery;

        protected async Task<Delivery> GetAndAssertDeliveryAsync()
        {
            this._delivery  = Build();

            var result = await _unitOfWork.DeliveryRepository.AddAsync(this._delivery);

            await _unitOfWork.SaveChangesAsync();

            result.Should().NotBeNull();

            result.BarCode.Should().NotBeNull();

            result.BarCode.Should().BeEquivalentTo(this._delivery.BarCode);

            return result;
        }

        protected Delivery GetAndAssertDelivery()
        {
            this._delivery  = Build();

            var result = _unitOfWork.DeliveryRepository.Add(this._delivery);

            _unitOfWork.SaveChanges();

            result.Should().NotBeNull();

            result.BarCode.Should().NotBeNull();

            result.BarCode.Should().BeEquivalentTo(this._delivery.BarCode);

            return result;
        }

        protected Delivery Build()
        {
            return new DeliveryBuilder()
                          .WithBarcode(15.ToRandomStringOfInts())
                          .WithWeight(2.ToRandomDecimal())
                          .WithOneDelivery()
                          .WithTwoPackages()
                          .Build();
        }
    }
}