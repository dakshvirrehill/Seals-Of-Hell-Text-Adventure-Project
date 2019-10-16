#include "Region.h"

Region::Region()
	:mName(""),mStory("")
{
}

Region::Region(std::string& pName, std::string& pStory)
	:mName(pName),mStory(pStory)
{
}

Region::~Region()
{
}
