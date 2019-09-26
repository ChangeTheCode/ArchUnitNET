﻿using System;
using System.Collections.Generic;
using System.Linq;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Extensions;
using static ArchUnitNET.Domain.Visibility;
using Attribute = ArchUnitNET.Domain.Attribute;

namespace ArchUnitNET.Fluent.Syntax.Elements
{
    public static class ObjectsConditionDefinition<TRuleType> where TRuleType : ICanBeAnalyzed
    {
        public static ExistsCondition<TRuleType> Exist()
        {
            return new ExistsCondition<TRuleType>(true);
        }

        public static SimpleCondition<TRuleType> Be(ICanBeAnalyzed firstObject, params ICanBeAnalyzed[] moreObjects)
        {
            var description = moreObjects.Aggregate("be \"" + firstObject.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            var failDescription = moreObjects.Aggregate("is not \"" + firstObject.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            return new SimpleCondition<TRuleType>(o => o.Equals(firstObject) || moreObjects.Any(o.Equals), description,
                failDescription);
        }

        public static SimpleCondition<TRuleType> DependOn(string pattern)
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.DependsOn(pattern), "depend on \"" + pattern + "\"",
                "does not depend on \"" + pattern + "\"");
        }

        public static SimpleCondition<TRuleType> OnlyDependOn(IType firstType, params IType[] moreTypes)
        {
            bool Condition(TRuleType ruleType)
            {
                return ruleType.Dependencies.Select(dependency => dependency.Target)
                    .All(target => target.Equals(firstType) || moreTypes.Contains(target));
            }

            var description = moreTypes.Aggregate("only depend on \"" + firstType.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            var failDescription = moreTypes.Aggregate(
                "does also depend on other types than just \"" + firstType.FullName + "\"",
                (current, obj) => current + " and \"" + obj.FullName + "\"");
            return new SimpleCondition<TRuleType>(Condition, description, failDescription);
        }

        public static ArchitectureCondition<TRuleType> OnlyDependOn(Type firstType, params Type[] moreTypes)
        {
            bool Condition(TRuleType ruleType, Architecture architecture)
            {
                return ruleType.Dependencies.Select(dependency => dependency.Target).All(target =>
                    target.Equals(architecture.GetTypeOfType(firstType)) ||
                    moreTypes.Any(type => architecture.GetTypeOfType(type).Equals(target)));
            }

            var description = moreTypes.Aggregate("only depend on \"" + firstType.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            var failDescription = moreTypes.Aggregate(
                "does also depend on other types than just \"" + firstType.FullName + "\"",
                (current, obj) => current + " and \"" + obj.FullName + "\"");
            return new ArchitectureCondition<TRuleType>(Condition, description, failDescription);
        }

        public static ArchitectureCondition<TRuleType> OnlyDependOn(IObjectProvider<IType> objectProvider)
        {
            bool Condition(TRuleType ruleType, Architecture architecture)
            {
                var types = objectProvider.GetObjects(architecture);
                return ruleType.Dependencies.Select(dependency => dependency.Target)
                    .All(target => types.Any(t => t.Equals(target)));
            }

            var description = "only depend on " + objectProvider.Description;
            var failDescription = "does also depend on other types than just " + objectProvider.Description;
            return new ArchitectureCondition<TRuleType>(Condition, description, failDescription);
        }

        public static SimpleCondition<TRuleType> OnlyDependOn(IEnumerable<IType> types)
        {
            var typeList = types.ToList();

            bool Condition(TRuleType type)
            {
                if (type.Dependencies.IsNullOrEmpty())
                {
                    return typeList.IsNullOrEmpty();
                }

                return type.Dependencies.Select(dependency => dependency.Target)
                    .All(target => typeList.Any(t => t.Equals(target)));
            }

            string description;
            string failDescription;
            if (typeList.IsNullOrEmpty())
            {
                description = "have no dependencies";
                failDescription = "has dependencies";
            }
            else
            {
                var firstType = typeList.First();
                description = typeList.Where(obj => !obj.Equals(firstType)).Distinct().Aggregate(
                    "only depend on \"" + firstType.FullName + "\"",
                    (current, obj) => current + " or \"" + obj.FullName + "\"");
                failDescription = typeList.Where(obj => !obj.Equals(firstType)).Distinct().Aggregate(
                    "does also depend on other types than just \"" + firstType.FullName + "\"",
                    (current, obj) => current + " and \"" + obj.FullName + "\"");
            }

            return new SimpleCondition<TRuleType>(Condition, description, failDescription);
        }

        public static SimpleCondition<TRuleType> HaveName(string name)
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.Name.Equals(name), "have name \"" + name + "\"",
                "does not have name \"" + name + "\"");
        }

        public static SimpleCondition<TRuleType> HaveFullName(string fullname)
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.FullName.Equals(fullname),
                "have full name \"" + fullname + "\"", "does not have full name \"" + fullname + "\"");
        }

        public static SimpleCondition<TRuleType> HaveNameStartingWith(string pattern)
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.NameStartsWith(pattern),
                "have name starting with \"" + pattern + "\"", "does not have name starting with \"");
        }

        public static SimpleCondition<TRuleType> HaveNameEndingWith(string pattern)
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.NameEndsWith(pattern),
                "have name ending with \"" + pattern + "\"", "does not have name ending with \"" + pattern + "\"");
        }

        public static SimpleCondition<TRuleType> HaveNameContaining(string pattern)
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.NameContains(pattern),
                "have name containing \"" + pattern + "\"", "does not have name containing \"" + pattern + "\"");
        }

        public static SimpleCondition<TRuleType> BePrivate()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility == Private, "be private", "is not private");
        }

        public static SimpleCondition<TRuleType> BePublic()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility == Public, "be public", "is not public");
        }

        public static SimpleCondition<TRuleType> BeProtected()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility == Protected, "be protected",
                "is not protected");
        }

        public static SimpleCondition<TRuleType> BeInternal()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility == Internal, "be internal", "is not internal");
        }

        public static SimpleCondition<TRuleType> BeProtectedInternal()
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.Visibility == ProtectedInternal, "be protected internal",
                "is not protected internal");
        }

        public static SimpleCondition<TRuleType> BePrivateProtected()
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.Visibility == PrivateProtected, "be private protected",
                "is not private protected");
        }


        //Relation Conditions

        public static RelationCondition<TRuleType, Class> DependOnClassesThat()
        {
            return new RelationCondition<TRuleType, Class>((obj, cls) => obj.DependsOn(cls.FullName),
                "depend on classes that",
                "does not depend on classes that");
        }

        public static RelationCondition<TRuleType, Attribute> HaveAttributesThat()
        {
            return new RelationCondition<TRuleType, Attribute>((obj, attribute) => obj.Attributes.Contains(attribute),
                "have attributes that", "does not have attributes that");
        }


        //Negations


        public static ExistsCondition<TRuleType> NotExist()
        {
            return new ExistsCondition<TRuleType>(false);
        }

        public static SimpleCondition<TRuleType> NotBe(ICanBeAnalyzed firstObject, params ICanBeAnalyzed[] moreObjects)
        {
            var description = moreObjects.Aggregate("not be \"" + firstObject.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            var failDescription = moreObjects.Aggregate("is not \"" + firstObject.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            return new SimpleCondition<TRuleType>(o => !o.Equals(firstObject) && !moreObjects.Any(o.Equals),
                description, failDescription);
        }

        public static SimpleCondition<TRuleType> NotDependOn(string pattern)
        {
            return new SimpleCondition<TRuleType>(
                obj => !obj.DependsOn(pattern), "not depend on \"" + pattern + "\"",
                "does depend on \"" + pattern + "\"");
        }

        public static SimpleCondition<TRuleType> NotDependOn(IType firstType, params IType[] moreTypes)
        {
            bool Condition(TRuleType ruleType)
            {
                return ruleType.Dependencies.Select(dependency => dependency.Target)
                    .All(target => !target.Equals(firstType) && !moreTypes.Contains(target));
            }

            var description = moreTypes.Aggregate("not depend on \"" + firstType.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            var failDescription = moreTypes.Aggregate("does depend on \"" + firstType.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            return new SimpleCondition<TRuleType>(Condition, description, failDescription);
        }

        public static ArchitectureCondition<TRuleType> NotDependOn(Type firstType, params Type[] moreTypes)
        {
            bool Condition(TRuleType ruleType, Architecture architecture)
            {
                return ruleType.Dependencies.Select(dependency => dependency.Target).All(target =>
                    !target.Equals(architecture.GetTypeOfType(firstType)) &&
                    moreTypes.All(type => !architecture.GetTypeOfType(type).Equals(target)));
            }

            var description = moreTypes.Aggregate("not depend on \"" + firstType.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            var failDescription = moreTypes.Aggregate("does depend on \"" + firstType.FullName + "\"",
                (current, obj) => current + " or \"" + obj.FullName + "\"");
            return new ArchitectureCondition<TRuleType>(Condition, description, failDescription);
        }

        public static ArchitectureCondition<TRuleType> NotDependOn(IObjectProvider<IType> objectProvider)
        {
            bool Condition(TRuleType ruleType, Architecture architecture)
            {
                var types = objectProvider.GetObjects(architecture);
                return ruleType.Dependencies.Select(dependency => dependency.Target)
                    .All(target => types.All(t => !t.Equals(target)));
            }

            var description = "not depend on " + objectProvider.Description;
            var failDescription = "does depend on " + objectProvider.Description;
            return new ArchitectureCondition<TRuleType>(Condition, description, failDescription);
        }

        public static SimpleCondition<TRuleType> NotDependOn(IEnumerable<IType> types)
        {
            var typeList = types.ToList();

            bool Condition(TRuleType type)
            {
                return type.Dependencies.Select(dependency => dependency.Target)
                    .All(target => typeList.All(t => !t.Equals(target)));
            }

            string description;
            string failDescription;
            if (typeList.IsNullOrEmpty())
            {
                description = "not depend on no types (always true)";
                failDescription = "does depend on one of no types (impossible)";
            }
            else
            {
                var firstType = typeList.First();
                description = typeList.Where(obj => !obj.Equals(firstType)).Distinct().Aggregate(
                    "not depend on \"" + firstType.FullName + "\"",
                    (current, obj) => current + " or \"" + obj.FullName + "\"");
                failDescription = typeList.Where(obj => !obj.Equals(firstType)).Distinct().Aggregate(
                    "does depend on \"" + firstType.FullName + "\"",
                    (current, obj) => current + " or \"" + obj.FullName + "\"");
            }

            return new SimpleCondition<TRuleType>(Condition, description, failDescription);
        }

        public static SimpleCondition<TRuleType> NotHaveName(string name)
        {
            return new SimpleCondition<TRuleType>(
                obj => !obj.Name.Equals(name), "not have name \"" + name + "\"", "does have name \"" + name + "\"");
        }

        public static SimpleCondition<TRuleType> NotHaveFullName(string fullname)
        {
            return new SimpleCondition<TRuleType>(
                obj => !obj.FullName.Equals(fullname), "not have full name \"" + fullname + "\"",
                "does have full name \"" + fullname + "\"");
        }

        public static SimpleCondition<TRuleType> NotHaveNameStartingWith(string pattern)
        {
            return new SimpleCondition<TRuleType>(obj => !obj.NameStartsWith(pattern),
                "not have name starting with \"" + pattern + "\"", "does have name starting with \"" + pattern + "\"");
        }

        public static SimpleCondition<TRuleType> NotHaveNameEndingWith(string pattern)
        {
            return new SimpleCondition<TRuleType>(obj => !obj.NameEndsWith(pattern),
                "not have name ending with \"" + pattern + "\"", "does have name ending with \"" + pattern + "\"");
        }

        public static SimpleCondition<TRuleType> NotHaveNameContaining(string pattern)
        {
            return new SimpleCondition<TRuleType>(obj => !obj.NameContains(pattern),
                "not have name containing \"" + pattern + "\"", "does have name containing \"" + pattern + "\"");
        }

        public static SimpleCondition<TRuleType> NotBePrivate()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility != Private, "not be private", "is private");
        }

        public static SimpleCondition<TRuleType> NotBePublic()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility != Public, "not be public", "is public");
        }

        public static SimpleCondition<TRuleType> NotBeProtected()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility != Protected, "not be protected",
                "is protected");
        }

        public static SimpleCondition<TRuleType> NotBeInternal()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility != Internal, "not be internal", "is internal");
        }

        public static SimpleCondition<TRuleType> NotBeProtectedInternal()
        {
            return new SimpleCondition<TRuleType>(
                obj => obj.Visibility != ProtectedInternal, "not be protected internal", "is protected internal");
        }

        public static SimpleCondition<TRuleType> NotBePrivateProtected()
        {
            return new SimpleCondition<TRuleType>(obj => obj.Visibility != PrivateProtected, "not be private protected",
                "is private protected");
        }


        //Relation Conditions Negations

        public static RelationCondition<TRuleType, Class> NotDependOnClassesThat()
        {
            return new RelationCondition<TRuleType, Class>((obj, cls) => !obj.DependsOn(cls.FullName),
                "not depend on classes that", "does depend on classes that");
        }

        public static RelationCondition<TRuleType, Attribute> NotHaveAttributesThat()
        {
            return new RelationCondition<TRuleType, Attribute>((obj, attribute) => !obj.Attributes.Contains(attribute),
                "not have attributes that", "does have attributes that");
        }
    }
}