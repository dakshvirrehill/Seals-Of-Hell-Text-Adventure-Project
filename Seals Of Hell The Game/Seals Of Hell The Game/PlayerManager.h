#pragma once
#ifndef PLAYER_MANAGER_H
#define PLAYER_MANAGER_H
class PlayerManager
{
private:
	inline explicit PlayerManager() {}
	inline ~PlayerManager() {}
	inline explicit PlayerManager(PlayerManager const&) {}
	inline PlayerManager& operator=(PlayerManager const&)
	{
		return *this;
	}
protected:
	inline static PlayerManager& instance()
	{
		static PlayerManager mInstance;
		return mInstance;
	}
	void inventory();
	friend class GameManager;
	friend class CommandManager;
};
#endif