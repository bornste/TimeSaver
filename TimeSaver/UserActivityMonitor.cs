using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TimeSaver
{
    /// <summary>
    /// Defines the different types of user activity.
    /// </summary>
    [Flags]
    public enum UserActivities
    {
        /// <summary>
        /// No activity
        /// </summary>
        None = 0,

        /// <summary>
        /// The mouse was clicked.
        /// </summary>
        MouseClick = 1,

        /// <summary>
        /// The mouse was moved.
        /// </summary>
        MouseMove = 2,

        /// <summary>
        /// A key on the keyboard was pressed.
        /// </summary>
        Keyboard = 4,

        /// <summary>
        /// All activities are tracked.
        /// </summary>
        All = 0xffff
    }

    /// <summary>
    /// Represents a subscriber that is interested in user activities.
    /// </summary>
    public interface IUserActivitySubscriber
    {
        /// <summary>
        /// Notifies the subscriber that the user is active.
        /// </summary>
        /// <param name="activity">The performed activity by the user.</param>
        void Notify(UserActivities activity);
    }

    /// <summary>
    /// Provides notifications about user activity, i.e. keyboard and mouse events.
    /// </summary>
    public class UserActivityMonitor : IDisposable, IMessageFilter
    {
        /// <summary>
        /// Initializes a new instance of the UserActivityMonitor class,
        /// that monitors MouseClick and Keyboard activities.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        public UserActivityMonitor(IUserActivitySubscriber subscriber)
            : this(subscriber, UserActivities.MouseClick | UserActivities.Keyboard)
        {
        }

        /// <summary>
        /// Initializes a new instance of the UserActivityMonitor class,
        /// that monitors the specified activities.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="activities">The activities where the subscriber is interested in.</param>
        public UserActivityMonitor(IUserActivitySubscriber subscriber, UserActivities activities)
        {
            // set subscriber
            m_subscriber = subscriber;

            // set requested activities
            m_activities = activities;

            // split up activities for better performance
            m_monitorMouseClickEvents =
                (m_activities & UserActivities.MouseClick) == UserActivities.MouseClick;
            m_monitorMouseMoveEvents =
                (m_activities & UserActivities.MouseMove) == UserActivities.MouseMove;
            m_monitorKeyboardEvents =
                (m_activities & UserActivities.Keyboard) == UserActivities.Keyboard;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the monitor is active or not.
        /// </summary>
        public bool Active
        {
            get { return m_active; }
            set
            {
                // something else?
                if (m_active != value)
                {
                    m_active = value;

                    // active?
                    if (m_active)
                    {
                        // add message filter
                        Application.AddMessageFilter(this);
                    }
                    else
                    {
                        // remove message filter
                        Application.RemoveMessageFilter(this);
                    }
                }
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Disposes this instance and removes the message filter.
        /// </summary>
        public void Dispose()
        {
            // remove message filter
            if (m_active)
                Application.RemoveMessageFilter(this);

            // release subscriber
            m_subscriber = null;
        }

        #endregion // IDisposable Members

        #region IMessageFilter Members

        /// <summary>
        /// Filters out a message before it is dispatched.
        /// </summary>
        /// <param name="m">The message to be dispatched. You cannot modify this message.</param>
        /// <returns>
        /// true to filter the message and stop it from being dispatched;
        /// false to allow the message to continue to the next filter or control.</returns>
        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            // dirty?
            if (m_active)
            {
                // get the message
                Messages message = (Messages)m.Msg;

                // keyboard
                if (m_monitorKeyboardEvents)
                {
                    // key down or up?
                    if (message == Messages.WM_KEYDOWN)
                    {
                        Notify(UserActivities.Keyboard);
                        return false;
                    }
                }

                // mouse click
                if (m_monitorMouseClickEvents)
                {
                    // key down or up?
                    if (message == Messages.WM_LBUTTONDOWN ||
                        message == Messages.WM_MBUTTONDOWN ||
                        message == Messages.WM_RBUTTONDOWN ||
                        message == Messages.WM_MOUSEWHEEL)
                    {
                        Notify(UserActivities.MouseClick);
                        return false;
                    }
                }

                // mouse move
                if (m_monitorMouseMoveEvents)
                {
                    // mouse move?
                    if (message == Messages.WM_MOUSEMOVE)
                    {
                        Notify(UserActivities.MouseMove);
                        return false;
                    }
                }
            }

            return false;
        }

        #endregion // IMessageFilter Members

        /// <summary>
        /// Notifies the subscriber about a user activity.
        /// </summary>
        /// <param name="activity">The activity of the user.</param>
        private void Notify(UserActivities activity)
        {
            // NOT null?
            if (m_subscriber != null)
                m_subscriber.Notify(activity);
        }

        // private members
        private bool m_active = false;
        private IUserActivitySubscriber m_subscriber = null;
        private UserActivities m_activities = UserActivities.None;
        private bool m_monitorMouseClickEvents = false;
        private bool m_monitorMouseMoveEvents = false;
        private bool m_monitorKeyboardEvents = false;

    }
}
