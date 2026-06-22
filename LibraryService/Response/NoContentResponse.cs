
    public class NoContentResponse : Response
    {
      public NoContentResponse() : base(true, "NoContent")
     {
        
     }

     public static NoContentResponse Success(string? message = "")
     {
        return new NoContentResponse();
     }

    }
