using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace SimpleMvp.Base
{
    public static class BindingHelper
    {
        public static string Name<T>(Expression<Func<T>> expression)
        {
            return GetMemberName(expression.Body);
        }

        public static void Bind<TModel>(this TextBox textBox, BindingSource bindingSource, Expression<Func<TModel, object>> dataMember)
        {
            textBox.DataBindings.Add("Text", bindingSource, Name(dataMember), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void Bind<TModel>(this Label control, BindingSource bindingSource, Expression<Func<TModel, object>> dataMember)
        {
            control.DataBindings.Add("Text", bindingSource, Name(dataMember), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void Bind<TModel>(this CheckBox control, BindingSource bindingSource, Expression<Func<TModel, object>> dataMember)
        {
            control.DataBindings.Add("Enabled", bindingSource, Name(dataMember), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void Bind<TModel>(this NumericUpDown control, BindingSource bindingSource, Expression<Func<TModel, object>> dataMember)
        {
            control.DataBindings.Add("Value", bindingSource, Name(dataMember), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void Bind<TModel>(this ComboBox control, BindingSource bindingSource, Expression<Func<TModel, object>> dataMember)
        {
            control.DataBindings.Add("SelectedValue", bindingSource, Name(dataMember), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void Bind<TModel>(this ListBox control, BindingSource bindingSource, Expression<Func<TModel, object>> dataMember)
        {
            control.DataBindings.Add("SelectedValue", bindingSource, Name(dataMember), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void SetDisplayAndValueMember<TModel>(this ListControl listControl, BindingSource bindingSource, Expression<Func<TModel, object>> displayMember, Expression<Func<TModel, object>> valueMember)
        {
            listControl.DisplayMember = Name(displayMember);
            listControl.ValueMember = Name(valueMember);
            listControl.DataSource = bindingSource;
        }

        public static void SetDisplayAndValueMember<TModel>(this ListControl listControl, IEnumerable<TModel> list, Expression<Func<TModel, object>> displayMember, Expression<Func<TModel, object>> valueMember)
        {
            listControl.DisplayMember = Name(displayMember);
            listControl.ValueMember = Name(valueMember);
            listControl.DataSource = list;
        }

        public static string Name<T, T2>(Expression<Func<T, T2>> expression)
        {
            return GetMemberName(expression.Body);
        }

        private static string GetMemberName(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expression;
                    var supername = GetMemberName(memberExpression.Expression);
                    if (String.IsNullOrEmpty(supername)) return memberExpression.Member.Name;
                    return String.Concat(supername, '.', memberExpression.Member.Name);
                case ExpressionType.Call:
                    var callExpression = (MethodCallExpression)expression;
                    return callExpression.Method.Name;
                case ExpressionType.Convert:
                    var unaryExpression = (UnaryExpression)expression;
                    return GetMemberName(unaryExpression.Operand);
                case ExpressionType.Parameter:
                case ExpressionType.Constant: //Change
                    return String.Empty;
                default:
                    throw new ArgumentException("The expression is not a member access or method call expression");
            }
        }
    }
}