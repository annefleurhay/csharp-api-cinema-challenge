using api_cinema_challenge.Data;
using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repository
{
    public class Repository : IRepository
    {
        public Customer CreateCustomer(Customer customer)
        {
            using (var cc = new CinemaContext())
            {
                cc.Customers.Add(customer);
                cc.SaveChanges();
                return customer;
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (var cc = new CinemaContext())
            {
                return cc.Customers.ToList();
            }


        }

        public Customer UpdateCustomer(Customer customer)
        {
            using (var cc = new CinemaContext())
            {
                cc.Customers.Attach(customer);
                cc.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                cc.SaveChanges();
                return customer;
            }
        }

        public Customer GetCustomer(int id)
        {
            using (var cc = new CinemaContext())
            {
                var customer = cc.Customers.FirstOrDefault(c => c.id == id);
                return customer;
            }
        }

        public Customer DeleteCustomer(int id)
        {
            using (var cc = new CinemaContext())
            {
                var customer = cc.Customers.First(c => c.id == id);
                cc.Remove(customer);
                cc.SaveChanges();
                return customer;
            }
        }

        //Movie stuff

        public Movie CreateMovie(Movie movie)
        {
            using (var cc = new CinemaContext())
            {
                cc.Movies.Add(movie);
                cc.SaveChanges();
                return movie;
            }
        }

        public Screening CreateScreening(Screening screening)
        {
            using (var cc = new CinemaContext())
            {
                cc.Screenings.Add(screening);
                cc.SaveChanges();
                return screening;
            }
        }

        public IEnumerable<Movie> GetMovies()
        {
            using (var cc = new CinemaContext())
            {

                return cc.Movies.ToList();
            }
        }

        public Movie GetMovie(int id)
        {
            using (var cc = new CinemaContext())
            {
                var movie = cc.Movies.FirstOrDefault(c => c.id == id);
                return movie;
            }

        }

        public Movie UpdateMovie(Movie movie)
        {
            using (var cc = new CinemaContext())
            {
                cc.Movies.Attach(movie);
                cc.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                cc.SaveChanges();
                return movie;
            }
        }

        public Movie Deletemovie(int id)
        {
            using (var cc = new CinemaContext())
            {



                var movie = cc.Movies.FirstOrDefault(c => c.id == id);
             
                var results = cc.Screenings.Where(s => s.movieId == movie.id).ToList();
                cc.Screenings.RemoveRange(results);
                cc.Remove(movie);

                cc.SaveChanges();
                return movie;
            }

        }

        public IEnumerable<Screening> GetScreenings(int id)
        {
            using (var cc = new CinemaContext())
            {
                return cc.Screenings.Where(s => s.movieId == id).ToList();

            }
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            using (var cc = new CinemaContext())
            {
                cc.Tickets.Add(ticket);
                cc.SaveChanges();
                return ticket;
            }
        }

        public IEnumerable<Ticket> GetTickets()
        {
            using (var cc = new CinemaContext())
            {
                return cc.Tickets.ToList();
            }
        }


        //public IEnumerable<Screening> GetScreenings(int id)
        //{
        //    using (var cc = new CinemaContext())
        //    {
        //        return cc.Screenings.Where(s => s.movieId == id).ToList();

        //    }
        //}

        //public Screening CreateScreening(Screening screening)
        //{
        //    using (var cc = new CinemaContext())
        //    {
        //        cc.Screenings.Add(screening);
        //        cc.SaveChanges();
        //        return screening;
        //    }
        //}
    }
}
