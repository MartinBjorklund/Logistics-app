using Google.OrTools.ConstraintSolver;
using ICAMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAMVC.Services
{
    class DataModel
    {
    //    public long[,] DistanceMatrix = {
    //  {0, 548, 776, 696, 582, 274, 502, 194, 3080, 194, 536, 502, 388, 354, 468, 7760, 662},
    //  {548, 0, 684, 308, 194, 502, 730, 354, 696, 742, 1084, 594, 480, 674, 1016, 868, 1210},
    //  {776, 684, 0, 992, 878, 502, 274, 810, 468, 742, 400, 1278, 1164, 1130, 788, 1552, 754},
    //  {696, 308, 992, 0, 114, 650, 878, 502, 844, 890, 1232, 514, 628, 822, 1164, 560, 1358},
    //  {582, 194, 878, 114, 0, 536, 764, 388, 730, 776, 1118, 400, 514, 708, 1050, 674, 1244},
    //  {274, 502, 502, 650, 536, 0, 228, 308, 194, 240, 582, 776, 662, 628, 514, 1050, 708},
    //  {502, 730, 274, 878, 764, 228, 0, 536, 194, 468, 354, 1004, 890, 856, 514, 1278, 480},
    //  {194, 354, 810, 502, 388, 308, 536, 0, 342, 388, 730, 468, 354, 320, 662, 742, 856},
    //  {3080, 696, 468, 844, 730, 194, 194, 342, 0, 274, 388, 810, 696, 662, 320, 1084, 514},
    //  {194, 742, 742, 890, 776, 240, 468, 388, 274, 0, 342, 536, 422, 388, 274, 810, 468},
    //  {536, 1084, 400, 1232, 1118, 582, 354, 730, 388, 342, 0, 878, 764, 730, 388, 1152, 354},
    //  {502, 594, 1278, 514, 400, 776, 1004, 468, 810, 536, 878, 0, 114, 308, 650, 274, 844},
    //  {388, 480, 1164, 628, 514, 662, 890, 354, 696, 422, 764, 114, 0, 194, 536, 388, 730},
    //  {354, 674, 1130, 822, 708, 628, 856, 320, 662, 388, 730, 308, 194, 0, 342, 422, 536},
    //  {468, 1016, 788, 1164, 1050, 514, 514, 662, 320, 274, 388, 650, 536, 342, 0, 764, 194},
    //  {7760, 868, 1552, 560, 674, 1050, 1278, 742, 1084, 810, 1152, 274, 388, 422, 764, 0, 798},
    //  {662, 1210, 754, 1358, 1244, 708, 480, 856, 514, 468, 354, 844, 730, 536, 194, 798, 0}
    //};
    //    public long[,] DistanceMatrix = {
    //    {0,3500,2000,2300,3200,4300,4600,2300,3200,3900,2400},
    //    {3500,0,4700,4300,2000,7000,6600,4300,2100,5200,4400},
    //    {2000,4700,0,3500,4400,2600,4000,3800,4500,6100,1300},
    //    {2300,4300,3500,0,2900,4700,3900,2300,4200,2100,3200},
    //    {3200,2000,4400,2900,0,6900,6100,4000,1700,3200,4200},
    //    {4300,7000,2600,4700,6900,0,1800,1900,5800,4200,3100},
    //    {4600,6600,4000,3900,6200,1800,0,2500,6400,4800,3700},
    //    {2300,4300,3800,2300,4000,1900,2500,0,4000,2800,1900},
    //    {3200,2100,4500,4200,1700,5800,6400,4000,0,5000,4200},
    //    {3900,5200,6100,2100,3200,4200,4800,2800,5000,0,4500},
    //    { 2400,4400,1300,3200,4200,3100,3700,1900,4200,4500,0}
    //};
        public long[,] DistanceMatrix = {
            {0,3500,2000,2300,3200,4300,4600,2300,3200,3900,2400,10100,15700,16800,20300,20100,20800,26300,24500,23900,23800,24400,23700,24100,23600},
            {3500,0,4700,4300,2000,7000,6600,4300,2100,5200,4400,9500,15100,16200,19800,19500,20200,25700,24000,23300,23300,23800,23100,23500,23000},
            {2000,4700,0,3500,4400,2600,4000,3800,4500,6100,1300,11400,16900,18100,21600,21400,22100,27600,25800,25100,25100,25700,2500,25300,24900},
            {2300,4300,3500,0,2900,4700,3900,2300,4200,2100,3200,8400,13900,15100,18600,18400,19100,24600,22800,22100,22100,22700,22000,22300,21900},
            {3200,2000,4400,2900,0,6900,6100,4000,1700,3200,4200,7500,13100,14200,17700,17500,18200,23700,21900,21300,21200,21800,21100,21500,21000},
            {4300,7000,2600,4700,6900,0,1800,1900,5800,4200,3100,11800,17300,18500,22000,21800,22500,28000,26200,25500,25500,26100,25400,25700,25300},
            {4600,6600,4000,3900,6200,1800,0,2500,6400,4800,3700,12400,18000,19100,22600,22400,23100,28600,26800,26200,26100,26700,26000,26300,25900},
            {2300,4300,3800,2300,4000,1900,2500,0,4000,2800,1900,10300,15900,17100,20600,20300,21100,26600,24800,24100,24100,24600,24000,24300,23900},
            {3200,2100,4500,4200,1700,5800,6400,4000,0,5000,4200,5800,11700,12800,16300,16100,16800,22300,20500,19900,19800,20400,19700,20000,19600},
            {3900,5200,6100,2100,3200,4200,4800,2800,5000,0,4500,8900,14400,15600,19100,18800,19600,25100,23300,22600,22600,23200,22500,22800,22400},
            {2400,4400,1300,3200,4200,3100,3700,1900,4200,4500,0,10900,16400,17600,21100,20800,21600,27100,25300,24600,24600,25200,24500,24800,24400},
            {10100,9500,11400,8400,7500,11800,12400,10300,5800,8900,10900,0,7700,8800,12400,12100,12800,18300,16600,15900,15900,16400,15700,16100,15700},
            {15700,15100,16900,13900,13100,17300,18000,15900,11700,14400,16400,7700,0,1400,7900,7600,8400,13900,12100,11400,11400,12000,11300,11600,11200},
            {16800,16200,18100,15100,14200,18500,19100,17100,12800,15600,17600,8800,1400,0,6600,7300,8000,13500,11800,11100,11100,11600,10900,11300,10800},
            {20300,19800,21600,18600,17700,22000,22600,20600,16300,19100,21100,12400,7900,6600,0,350,1300,7700,5900,5200,5200,5700,5100,5400,5000},
            {20100,19500,21400,18400,17500,21800,22400,20300,16100,18800,20800,12100,7600,7300,350,0,900,7400,5700,5000,5000,5500,4800,5200,4700},
            {20800,20200,22100,19100,18200,22500,23100,21100,16800,19600,21600,12800,8400,8000,1300,900,0,8200,6400,5700,5700,6300,5600,5100,4600 },
            {26300,25700,27600,24600,23700,28000,28600,26600,22300,25100,27100,18300,13900,13500,7700,7400,8200,0,700,1200,2100,2400,6000,6400,5900},
            {24500,24000,25800,22800,21900,26200,26800,24800,20500,23300,25300,16600,12100,11800,5900,5700,6400,700,0,650,1500,2600,3900,4200,3800},
            {23900,23300,25100,22100,21300,25500,26200,24100,19900,22600,24600,15900,11400,11100,5200,5000,5700,1200,650,0,600,1000,3500,3800,3400},
            {23800,23300,25100,22100,21200,25500,26100,24100,19800,22600,24600,15900,11400,11100,5200,5000,5700,2100,1500,600,0,1400,3400,3800,3300},
            {24400,23800,25700,22700,21800,26100,26700,24600,20400,23200,25200,16400,12000,11600,5700,5500,6300,2400,2600,1000,1400,0,4100,4400,4000},
            {23700,23100,25000,22000,21100,25400,26000,24000,19700,22500,24500,15700,11300,10900,5100,4800,5600,6000,3900,3500,3400,4100,0,1300,1700},
            {24100,23500,25300,22300,21500,25700,26300,24300,20000,22800,24800,16100,11600,11300,5400,5200,5100,6400,4200,3800,3800,4400,1300,0,700},
            {23600,23000,24900,21900,21000,25300,25900,23900,19600,22400,24400,15700,11200,10800,5000,4700,4600,5900,3800,3400,3300,4000,1700,700,0}
    };
        public int VehicleNumber = 5;
        public int Depot = 0;
        public long[] Demands = { 0, 1, 1, 2, 10, 3, 4, 8, 8, 1, 10, 1, 2, 6, 4, 8, 8, 12, 4, 6, 2, 1, 2, 6, 4 };
        public long[] VehicleCapacities = { 30, 30, 30, 30, 30 };
    };
    public class RenderRoutes
    {
        static List<Route> ReviewSolution(
        in DataModel data,
        in RoutingModel routing,
        in RoutingIndexManager manager,
        in Assignment solution)
        {
            var listOfRoutes = new List<Route>();
            var listOfCoordinates = LoadAllCoordinates();
            

            // Inspect solution.
            long totalDistance = 0;
            long totalLoad = 0;
            int numberOfValidRoutes = 1;
            for (int i = 0; i < data.VehicleNumber; ++i)
            {
                long routeDistance = 0;
                long routeLoad = 0;
                var index = routing.Start(i);
                var coordinates = new List<Coordinate>();
                var numberOfCustomers = 0;
                while (routing.IsEnd(index) == false)
                {
                    long nodeIndex = manager.IndexToNode(index);
                    routeLoad += data.Demands[nodeIndex];
                    Console.Write("{0} Load({1}) -> ", nodeIndex, routeLoad);

                    coordinates.Add(listOfCoordinates[manager.IndexToNode(index)]);
                    var previousIndex = index;
                    index = solution.Value(routing.NextVar(index));
                    routeDistance += routing.GetArcCostForVehicle(previousIndex, index, 0);
                    numberOfCustomers++;

            }
                if (numberOfCustomers > 1)
                {
                    listOfRoutes.Add(new Route { Distance = routeDistance / 1000, RouteName = $"Tur {numberOfValidRoutes}", NumberOfCustomers = numberOfCustomers, ListOfCoordinates = coordinates });
                    numberOfValidRoutes++;
                }
                totalDistance += routeDistance;
                totalLoad += routeLoad;

            }
            return listOfRoutes;
        }

        private static List<Coordinate> LoadAllCoordinates()
        {
            var listOfCoordinates = new List<Coordinate>();
                listOfCoordinates.Add(new Coordinate { Longitude = 60.496438, Latitude = 15.423272 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.505300, Latitude = 15.447738 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.506361, Latitude = 15.419138 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.485299, Latitude = 15.438885 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.491799, Latitude = 15.463323 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.497797, Latitude = 15.393570 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.488891, Latitude = 15.398027 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.489820, Latitude = 15.414643 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.500019, Latitude = 15.470584 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.473966, Latitude = 15.429415 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.501462, Latitude = 15.414189 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.512788, Latitude = 15.551307 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.549458, Latitude = 15.603665 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.550043, Latitude = 15.622884 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.591563, Latitude = 15.614464 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.593979, Latitude = 15.612469 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.597278, Latitude = 15.599969 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.617086, Latitude = 15.642144 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.618844, Latitude = 15.636133 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.621314, Latitude = 15.630532 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.623472, Latitude = 15.624980 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.626812, Latitude = 15.625488 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.624795, Latitude = 15.595675 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.622800, Latitude = 15.590854 });
                listOfCoordinates.Add(new Coordinate { Longitude = 60.618191, Latitude = 15.590889 });
            return listOfCoordinates;
        }

        public static List<Route> Generate()
        {

            DataModel data = new DataModel();


            RoutingIndexManager manager = new RoutingIndexManager(
                data.DistanceMatrix.GetLength(0),
                data.VehicleNumber,
                data.Depot);



            RoutingModel routing = new RoutingModel(manager);

            // Create and register a transit callback.
            int transitCallbackIndex = routing.RegisterTransitCallback(
                (long fromIndex, long toIndex) => {
                    // Convert from routing variable Index to distance matrix NodeIndex.
                    var fromNode = manager.IndexToNode(fromIndex);
                    var toNode = manager.IndexToNode(toIndex);
                    return data.DistanceMatrix[fromNode, toNode];
                }
                );

            // Define cost of each arc.
            routing.SetArcCostEvaluatorOfAllVehicles(transitCallbackIndex);



            // Add Capacity constraint.
            int demandCallbackIndex = routing.RegisterUnaryTransitCallback(
              (long fromIndex) => {
          // Convert from routing variable Index to demand NodeIndex.
          var fromNode = manager.IndexToNode(fromIndex);
                  return data.Demands[fromNode];
              }
            );
            routing.AddDimensionWithVehicleCapacity(
              demandCallbackIndex, 0,  // null capacity slack
              data.VehicleCapacities,   // vehicle maximum capacities
              true,                      // start cumul to zero
              "Capacity");

            // Setting first solution heuristic.
            RoutingSearchParameters searchParameters =
              operations_research_constraint_solver.DefaultRoutingSearchParameters();
            //searchParameters.UseDepthFirstSearch = true;
            searchParameters.FirstSolutionStrategy =
              FirstSolutionStrategy.Types.Value.Automatic;

            // Solve the problem.
            Assignment solution = routing.SolveWithParameters(searchParameters);

            // Print solution on console.
            return ReviewSolution(data, routing, manager, solution);
        }
    }
}
