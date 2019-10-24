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
	Gateway() : IInteractable(), mCurrentRoom(nullptr), mConnectedRoom(nullptr) {}
	~Gateway();
	void initialize(Room*,Room*);
	void lookObject() override;
	void goDirection() override;

};
#endif