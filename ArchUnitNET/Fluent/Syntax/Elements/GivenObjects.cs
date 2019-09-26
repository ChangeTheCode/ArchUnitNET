﻿using System.Collections.Generic;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Exceptions;
using static ArchUnitNET.Fluent.Syntax.ActivatorHandler;

namespace ArchUnitNET.Fluent.Syntax.Elements
{
    public abstract class GivenObjects<TRuleTypeThat, TRuleTypeShould, TRuleType> : SyntaxElement<TRuleType>,
        IObjectProvider<TRuleType>
        where TRuleType : ICanBeAnalyzed
    {
        protected GivenObjects(IArchRuleCreator<TRuleType> ruleCreator) : base(ruleCreator)
        {
        }

        public IEnumerable<TRuleType> GetObjects(Architecture architecture)
        {
            try
            {
                return _ruleCreator.GetFilteredObjects(architecture);
            }
            catch (CannotGetObjectsOfCombinedArchRuleCreatorException exception)
            {
                throw new CannotGetObjectsOfCombinedArchRuleException(
                    "GetObjects() can't be used with CombinedArchRule \"" + ToString() +
                    "\" because the analyzed objects might be of different type. Try to use simple ArchRules instead.",
                    exception);
            }
        }

        public TRuleTypeThat That()
        {
            return CreateSyntaxElement<TRuleTypeThat, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShould Should()
        {
            return CreateSyntaxElement<TRuleTypeShould, TRuleType>(_ruleCreator);
        }
    }
}