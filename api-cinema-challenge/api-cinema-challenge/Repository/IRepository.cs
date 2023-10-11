using api_cinema_challenge.EndPoints;
using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repository
{
    public interface IRepository
    {

        IEnumerable<Customer> GetCustomers();

        Customer CreateCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

        Customer GetCustomer(int id);

        Customer DeleteCustomer(int id);

        //Movie stuff

        Movie CreateMovie(Movie movie);


        Screening CreateScreening(Screening screening); 
        IEnumerable<Movie> GetMovies();

        Movie GetMovie(int id);

        Movie UpdateMovie(Movie movie);

        Movie Deletemovie(int id);

        IEnumerable<Screening> GetScreenings(int id);

        //Ticket

        Ticket CreateTicket(Ticket ticket);
        IEnumerable<Ticket> GetTickets();
    }
}
