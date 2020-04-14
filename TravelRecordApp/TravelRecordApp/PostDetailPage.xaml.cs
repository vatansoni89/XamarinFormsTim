using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        Post postDetail;
        public PostDetailPage(Post post)
        {
            InitializeComponent();
            postDetail = post;

            experienceEntry.Text = post.Experience;
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            postDetail.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(postDetail);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully updated", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Failed to update", "Ok");
                }
                
            }
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(postDetail);

                if (rows > 0)
                {
                    experienceEntry.Text = string.Empty;
                    DisplayAlert("Success", "Experience successfully deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Failed to delete", "Ok");
                }
                
            }
        }
    }
}