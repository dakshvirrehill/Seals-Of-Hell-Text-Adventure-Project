#pragma once
#ifndef TREASURE_ITEM_H
#define TREASURE_ITEM_H
#include "IInteractable.h"
class TreasureItem : public IInteractable
{
public:
	void pickObject() override;

};
#endif