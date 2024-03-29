#pragma once
#ifndef TREASURE_COLLECTOR_H
#define TREASURE_COLLECTOR_H
#include "IInteractable.h"
#include "IUpdatable.h"
#include <map>
#include <string>
/*
################
Treasure collector is responsible for collecting all giveables once the player has all of them
It is an updatable object because it can spawn last minute enemies to stop the player (final boss)
################
*/
class TreasureCollector : public IInteractable , public IUpdatable
{
	std::map<std::string,IInteractable*> mTreasures;
public:
	TreasureCollector() : IInteractable(),IUpdatable(),mTreasures() {}
	~TreasureCollector();
	void onEnable() override;
	void update() override;
	void endUpdate() override;
	void giveObject(IInteractable*) override;
	void addTreasures(IInteractable*);
	json::JSON getItemJSON() override;
	std::string getType() override { return "TreasureCollector"; }
};
#endif