﻿using System;
using System.Collections.Generic;
using ArchUnitNET.Domain;
using static ArchUnitNET.Fluent.Syntax.ConjunctionFactory;

namespace ArchUnitNET.Fluent.Syntax.Elements.Types

{
    public class GivenTypesThat<TGivenRuleTypeConjunction, TRuleType> :
        GivenObjectsThat<TGivenRuleTypeConjunction, TRuleType>, ITypePredicates<TGivenRuleTypeConjunction>
        where TRuleType : IType
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public GivenTypesThat(IArchRuleCreator<TRuleType> ruleCreator) : base(ruleCreator)
        {
        }

        public TGivenRuleTypeConjunction Are(Type firstType, params Type[] moreTypes)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.Are(firstType, moreTypes));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction Are(IEnumerable<Type> types)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.Are(types));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreAssignableToTypesWithFullNameMatching(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.AreAssignableToTypesWithFullNameMatching(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreAssignableToTypesWithFullNameContaining(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.AreAssignableToTypesWithFullNameContaining(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreAssignableTo(IType firstType, params IType[] moreTypes)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreAssignableTo(firstType, moreTypes));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreAssignableTo(Type firstType, params Type[] moreTypes)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreAssignableTo(firstType, moreTypes));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreAssignableTo(ObjectProvider<IType> types)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreAssignableTo(types));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreAssignableTo(IEnumerable<IType> types)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreAssignableTo(types));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreAssignableTo(IEnumerable<Type> types)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreAssignableTo(types));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction ImplementInterfaceWithFullNameMatching(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.ImplementInterfaceWithFullNameMatching(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction ImplementInterfaceWithFullNameContaining(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.ImplementInterfaceWithFullNameContaining(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction ResideInNamespaceWithFullNameMatching(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.ResideInNamespaceWithFullNameMatching(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction ResideInNamespaceWithFullNameContaining(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.ResideInNamespaceWithFullNameContaining(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction ResideInAssemblyWithFullNameMatching(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.ResideInAssemblyWithFullNameMatching(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction ResideInAssemblyWithFullNameContaining(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.ResideInAssemblyWithFullNameContaining(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction HavePropertyMemberWithName(string name)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.HavePropertyMemberWithName(name));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction HaveFieldMemberWithName(string name)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.HaveFieldMemberWithName(name));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction HaveMethodMemberWithName(string name)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.HaveMethodMemberWithName(name));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction HaveMemberWithName(string name)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.HaveMemberWithName(name));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNested()
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNested());
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }


        //Negations


        public TGivenRuleTypeConjunction AreNot(Type firstType, params Type[] moreTypes)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNot(firstType, moreTypes));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNot(IEnumerable<Type> types)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNot(types));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNotAssignableToTypesWithFullNameMatching(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.AreNotAssignableToTypesWithFullNameMatching(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNotAssignableToTypesWithFullNameContaining(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.AreNotAssignableToTypesWithFullNameContaining(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNotAssignableTo(IType firstType, params IType[] moreTypes)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNotAssignableTo(firstType, moreTypes));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNotAssignableTo(Type firstType, params Type[] moreTypes)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNotAssignableTo(firstType, moreTypes));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNotAssignableTo(ObjectProvider<IType> types)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNotAssignableTo(types));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNotAssignableTo(IEnumerable<IType> types)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNotAssignableTo(types));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNotAssignableTo(IEnumerable<Type> types)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNotAssignableTo(types));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotImplementInterfaceWithFullNameMatching(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.DoNotImplementInterfaceWithFullNameMatching(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotImplementInterfaceWithFullNameContaining(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.DoNotImplementInterfaceWithFullNameContaining(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotResideInNamespaceWithFullNameMatching(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.DoNotResideInNamespaceWithFullNameMatching(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotResideInNamespaceWithFullNameContaining(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.DoNotResideInNamespaceWithFullNameContaining(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotResideInAssemblyWithFullNameMatching(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.DoNotResideInAssemblyWithFullNameMatching(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotResideInAssemblyWithFullNameContaining(string pattern)
        {
            _ruleCreator.AddPredicate(
                TypePredicatesDefinition<TRuleType>.DoNotResideInAssemblyWithFullNameContaining(pattern));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotHavePropertyMemberWithName(string name)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.DoNotHavePropertyMemberWithName(name));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotHaveFieldMemberWithName(string name)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.DoNotHaveFieldMemberWithName(name));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotHaveMethodMemberWithName(string name)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.DoNotHaveMethodMemberWithName(name));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction DoNotHaveMemberWithName(string name)
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.DoNotHaveMemberWithName(name));
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }

        public TGivenRuleTypeConjunction AreNotNested()
        {
            _ruleCreator.AddPredicate(TypePredicatesDefinition<TRuleType>.AreNotNested());
            return Create<TGivenRuleTypeConjunction, TRuleType>(_ruleCreator);
        }
    }
}