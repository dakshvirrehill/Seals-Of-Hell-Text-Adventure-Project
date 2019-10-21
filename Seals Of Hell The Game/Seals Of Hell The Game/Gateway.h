#pragma once
#ifndef GATEWAY_H
#define GATEWAY_H
#include "IInteractable.h"
class Room;
class Gateway : public IInteractable
{
	Room* mCurrentRoom;
	Room* mConnectedRoom;

public:
	void initialize(Room*,Room*,bool&, bool&);
	void lookObject() override;
	void goDirection() override;

};
#endif