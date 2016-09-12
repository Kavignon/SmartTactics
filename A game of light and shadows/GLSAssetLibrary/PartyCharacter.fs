﻿module GLSAsset.PartyCharacter

open GLSAsset.CharacterInformation
open GLSAsset.GameElement

open System

(* - After Move, player will be able to choose any action
   - After Attack, player won't be able to use move or defend
   - After Defend, player won't be able to use move or atttack 
   - After Rotate, player won't be able to move 
   - After EndTurn, battle sequence will move to the next character
   - CheckInventory can be use at any time during the character's turn 
*)

type CharacterState = {
    CurrentPos       : CharacPos 
    CurrentDirection : PlayerDirection
}


[<AbstractClass>]
type CharacterBase(job: CharacterJob, state: CharacterState) =

    abstract member TeamParty: Object array

    abstract member ActionPoints: int

    abstract member MoveRange: MoveRange

    abstract member CharacterState: CharacterState

    member x.Job = job

    member x.Stats = job.Stats

type PartyCharacter(job: CharacterJob, 
                    equipment: CharacterEquipement,
                    style: CombatStyle, 
                    state: CharacterState,
                    team: Object array) = 
    inherit CharacterBase(job,state)

    member x.Job = job
    
    member x.Equipment = equipment 
    
    member x.CombatStyle = style 

    override x.ActionPoints = style.actionPoints
    
    override x.TeamParty = team  

    override x.MoveRange = job.Role.moveRange

    override x.CharacterState = state 

        