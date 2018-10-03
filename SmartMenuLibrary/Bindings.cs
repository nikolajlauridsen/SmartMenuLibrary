using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMenuLibrary {
    class Bindings {
        Dictionary<string, Action> binds;

        public Bindings() {
            binds = new Dictionary<string, Action>();
        }

        public void Bind(String id, Action action) {
            binds[id] = action;
        }

        public void Call(String id) {
            Action action = binds[id];
            action();
        }
    }
}
