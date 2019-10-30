#pragma once
#ifndef COMMAND_MANAGER_H
#define COMMAND_MANAGER_H
#include<vector>
#include<functional>
#include<map>
#include<string>
class IInteractable;
class CommandManager
{
private:
	inline explicit CommandManager() :mInteractableCommands(), mTwoInteractionCommands() ,mSingleCommands(), mInitialzed(false) {}
	inline ~CommandManager() {}
	inline explicit CommandManager(CommandManager const&) :mInteractableCommands(), mTwoInteractionCommands(), mSingleCommands(), mInitialzed(false) {}
	inline CommandManager& operator=(CommandManager const&)
	{
		return *this;
	}
	std::vector<std::string> getCommandWords(std::string&);
	void convertToUpper(std::string&);
	std::map<std::string, std::function<void(IInteractable*)>> mInteractableCommands;
	std::map < std::string, std::function<void(IInteractable*, IInteractable*)>> mTwoInteractionCommands;
	std::map<std::string, std::function<void ()>> mSingleCommands;
	bool mInitialzed;
protected:
	inline static CommandManager& instance()
	{
		static CommandManager mInstance;
		return mInstance;
	}
	void initialize();
	static void help();
	bool runCommand(std::string&);
	friend class GameManager;
};
#endif