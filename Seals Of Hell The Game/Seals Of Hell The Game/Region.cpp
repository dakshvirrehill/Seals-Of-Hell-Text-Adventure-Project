#include "Region.h"
#include <iostream>
Region::Region()
	:BasicObject()
{
}

Region::~Region()
{
	
}

void Region::initialize()
{
}

void Region::look()
{
	std::cout << getName() << std::endl <<std::endl;
	std::cout << getStory() << std::endl << std::endl <<std::endl;
}
