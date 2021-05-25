using System;

namespace Modele
{
    public class NotificationRelationEvent : EventArgs
    {
        public Relation LaRelation { get; private set; }
        public Personnage LePersonnage { get; private set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="personnage">Le personnage a notifié</param>
        /// <param name="relation">La relation dans laquelle il est mentionné</param>
        public NotificationRelationEvent(Personnage personnage, Relation relation)
        {
            LaRelation = relation;
            LePersonnage = personnage;
        }
    }
}