﻿using System;
using System.Linq;
using AutoFixture;
using Domain;

namespace TestBase
{
    public abstract class SpecBase
    {
        protected ScenarioForExisting<TAggregate> ScenarioForExisting<TAggregate>() where TAggregate : IAggregateRoot
        {
            return new ScenarioForExisting<TAggregate>();
        }
        
        protected ScenarioFor<TAggregate> ScenarioFor<TAggregate>(Func<TAggregate> constructor) where TAggregate : IAggregateRoot
        {
            return new ScenarioFor<TAggregate>(constructor);
        }
        
        private static readonly Fixture fixture = new Fixture();

        protected T Random<T>()
        {
            if (typeof(T) == typeof(long))
            {
                return (T) Convert.ChangeType(new Random().Next(),
                    typeof(T)); // workaround to avoid autoFixture's similer long values 
            }

            return fixture.Create<Generator<T>>().First();
        }
    }
}
