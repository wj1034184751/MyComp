using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace YuanTu.Platform.Utilities
{
     public class MapperUtil
    {
        public static T Mapper<T>(object source) where T: class, new()
        {
            T item = new T();

            if (typeof(T).Name == "List`1")
            {
                var list = source as IList;
                var targets = item as IList;
                if (list.Count == 0)
                    return item;

                Type st = list[0].GetType();

                for (var p = 0; p < list.Count; p++)
                {
                    targets.Add(MapperEntity(list[p], typeof(T).GenericTypeArguments[0]));
                }
            }
            else
            {
                item = MapperEntity<T>(source);
            }

            return item;
        }

        public static T MapperEntity<T>(object source) where T : class, new()
        {
            T item = new T();

            Type st = source.GetType();

            foreach (var prop in typeof(T).GetProperties())
            {
                var sprop = st.GetProperty(prop.Name);
                prop.SetValue(item, sprop.GetValue(source));
            }

            return default(T);
        }

        public static object MapperEntity(object source, Type target)
        {
           var item = Activator.CreateInstance(target);

            Type st = source.GetType();

            foreach (var prop in target.GetProperties())
            {
                var sprop = st.GetProperty(prop.Name);
                prop.SetValue(item, sprop.GetValue(source));
            }

            return item;
        }
    }
}
