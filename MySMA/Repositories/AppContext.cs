using System.Data.Entity;
using MySMA.Models;
using System.Data.Entity.Infrastructure;

namespace MySMA.Repositories
{
    public class AppContext : DbContext, IDbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<CaseStudyApp.Repositories.CaseStudyAppContext>());

        public AppContext()
            : base("name=AppContext") 
        {
#if !DEBUG
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 360; 
#endif
        }

        public IDbSet<Questionnaire> Questionnaires { get; set; }
        public IDbSet<QuestionBase> Questions { get; set; }

        /// <summary>
        /// Implement interface. This allows us to use a fake IDbSet in unit tests. This is necessary because the DbContext implementation is of type DbSet<T>.
        /// </summary>
        /// <typeparam name="T">Type of the DbSet to return</typeparam>
        /// <returns>DbSet of type T</returns>
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        /// <summary>
        /// This method is used to allow creating a fake DbContext with an alternate implementation of SetModified. This is due to the difficulty in 
        /// faking the DbContext.Entry method.
        /// </summary>
        /// <param name="entity"></param>
        public void SetModified<T>(T entity) where T : EntityBase
        {
            var entry = Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = Set<T>();

                // Determine if we have the entity in the set already
                T attachedEntity = set.Find(entity.Id);  // You need to have access to key

                if (attachedEntity != null)
                {
                    // If so then update it and set its state to modified
                    var attachedEntry = Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                    attachedEntry.State = EntityState.Modified;
                }
                else
                {
                    // If not, attach the entity
                    entry.State = EntityState.Modified;
                }
            }
        }

        public void Remove<T>(T entity) where T : EntityBase
        {
            Entry(entity).State = EntityState.Detached;
        }

        public bool AutoDetectChangesEnabled
        {
            get { return Configuration.AutoDetectChangesEnabled; }
            set { Configuration.AutoDetectChangesEnabled = value; }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}