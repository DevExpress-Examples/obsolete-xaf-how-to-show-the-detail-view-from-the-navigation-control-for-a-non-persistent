using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace WinWebSolution.Module {
    [DefaultClassOptions]
    [NonPersistent]
    public class MyNonPersistentDomainObject : BaseObject {
        public MyNonPersistentDomainObject(Session session) : base(session) { }
        public MyNonPersistentDomainObject(Session session, string name):base(session) {
            this.Name = name;
        }
        private string _name;
        public string Name {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }
    }
}
