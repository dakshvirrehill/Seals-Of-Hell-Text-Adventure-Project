#pragma once
#ifndef GAME_MANAGER_H
#define GAME_MANAGER_H
#include <string>
class GameManager
{
private:
	std::string mFileName;
	inline explicit GameManager() {}
	inline ~GameManager() {}
	inline explicit GameManager(GameManager const&) {}
	inline GameManager& operator=(GameManager const&) 
	{
		return *this;
	}
public:
	inline static GameManager& instance() 
	{
		static GameManager mInstance;
		return mInstance;
	}
	void StartGame(std::string&);
};
#endif