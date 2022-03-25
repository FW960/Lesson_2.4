using System;

namespace Construction
{
    public abstract class Building
    {
        protected static int LastBuildingNum = 0;

        protected int BuildingNum;

        protected int Height;

        protected int NumOfFloors;

        protected int NumOfApartments;

        protected int NumOfEntrances;
        protected Building() { }

    }
}
