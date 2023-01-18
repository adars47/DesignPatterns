using ObserverPattern;

weatherStation kathmandu = new weatherStation(10,45,12);

user adarsha= new user("Adarsha");
user barsha = new user("Barsha");
user abhaya = new user("Abhaya");


kathmandu.subscribe(adarsha,weatherStation.eventTypes.All);

kathmandu.subscribe(abhaya, weatherStation.eventTypes.Min);

kathmandu.subscribe(barsha, weatherStation.eventTypes.Max);

//temperature increased to 12
Console.WriteLine("Temperature increased to 12");
kathmandu.Temperature = 12;

Console.WriteLine("Temperature decreased to -1");
kathmandu.Temperature = -1;

Console.WriteLine("Unsubscribed user barsha from max listener \n ");
kathmandu.unsubscribe(barsha, weatherStation.eventTypes.Max);

Console.WriteLine("Temperature increased to 13");
kathmandu.Temperature = 13;