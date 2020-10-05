﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DE_guardBehaviour : MonoBehaviour
{
    //Speichert ob der Wächter gerade verfolgt oder nicht
    bool chase = false;

    //Wird true falls Spieler geschnappt wird, Game Over wenn true
    bool caught = false;

    //Speichert ob der Wächter bereits ein Ziel hat
    bool hasDest = false;

    //Timer bis neues Ziel
    float timer = 0;
    float waitTime = 10;

    //Rotationen für Wache halten
    Quaternion rotation;
    Quaternion origin;

    //Bool für Rotationen festlegen
    bool gotRotation1 = false;
    bool gotRotation2 = false;

    //Reichweite des Wächters
    float range = 80;

    //Agent des Wächters
    NavMeshAgent agent;

    //Spieler
    GameObject player;

    void Start()
    {
        //Agent holen
        agent = GetComponent<NavMeshAgent>();
        //Spieler holen
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            chase = true;
            agent.speed = 11f;
        }

        //Keine Verfolgung, Wächter patroulliert
        if(!chase){
            //Wächter hat kein Ziel, finde ein neues Ziel
            if(!hasDest){
                //Finde zufällige Position auf dem NavMesh
                NavMeshHit dest;
                NavMesh.SamplePosition(new Vector3(Random.Range(14,192), 0, Random.Range(-109,89)), out dest, 5, NavMesh.AllAreas);

                //Neues Ziel setzen
                agent.destination = dest.position;

                //Bool für Rotationen zurücksetzen
                gotRotation1 = false;
                gotRotation2 = false;

                //Wächter hat nun ein Ziel
                hasDest = true;
            } 
            //Wächter hat bereits ein Ziel, warte bis Wächter nahe am Ziel und warte dann eine Weile (waitTime)
            else{ 
                //Wenn Abstand zum Ziel kleiner als Eins -> starte das Warten
                if(agent.remainingDistance < 1)
                {
                    //Wartezeit vorbei, keine Ziel mehr vorhanden, Zeit zurücksetzen
                    if(timer >= waitTime){
                        hasDest = false;
                        timer = 0;
                    } 
                    //Warten
                    else{
                        timer += Time.deltaTime;
                    }

                    //Erste Drehung nach 20% der Wartezeit, Dauer 20%
                    if (timer > 0 && timer < 3 * waitTime / 5){
                        if(!gotRotation1){
                            //Roation festlegen                   
                            origin = transform.rotation;
                            rotation = origin * Quaternion.Euler(0,(Random.value > 0.5f) ? 181 : 179, 0);
                            gotRotation1 = true;
                        }
                    
                        //Wächter hält Wache (zufällige Rotationsbewegungen)
                        transform.rotation = Quaternion.Lerp(origin, rotation, (timer - waitTime/5) / ( waitTime/5));  
                    }

                    //Zweite Drehung nach 60% der Wartezeit, Dauer 20%
                    if (timer > 3 * waitTime / 5){
                        if(!gotRotation2){
                            //Roation festlegen                   
                            origin = transform.rotation;
                            rotation = origin * Quaternion.Euler(0,(Random.value > 0.5f) ? 90 : -90, 0);
                            gotRotation2 = true;
                        }
                    
                        //Wächter hält Wache (zufällige Rotationsbewegungen)
                        transform.rotation = Quaternion.Lerp(origin, rotation, (timer - 3*waitTime/5) / ( waitTime/5));  
                    }
                }
            }
        } 
        //Wächter befindet sich in einer Verfolgung
        else{
            NavMeshHit dest;
            NavMesh.SamplePosition(player.transform.position, out dest, 5, NavMesh.AllAreas);

            //Neues Ziel setzen
            agent.destination = dest.position;
            
            //Falls Weg nur noch 4.2 (Abstand wenn Wächter Spieler am Rücken klebt) -> geschnappt
            if(agent.remainingDistance < 4.2f){
                caught = true;
                Debug.Log("Caught!");
            }

            //Falls Weg größer als Reichweite und nicht nur gerade kein Weg berechnet -> entkommen
            if(agent.remainingDistance > range && agent.remainingDistance != Mathf.Infinity){
                Debug.Log("Escaped!");
                chase = false;
                agent.speed = 5;
            }
        }

        //Wenn (Bild zerstört oder gestohlen wird ODER Spieler hat gestohlenes Bild) UND Wächter ist in Reichweite UND Wächter hat Sichtkontakt -> Starte Verfolgung

        //Wenn Bild zerstört oder gestohlen wird ODER Spieler hat gestohlenes Bild
        if(((MW_playerColliderInteraction.owned == true && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2))) || MW_playerColliderInteraction.steal) && !chase){
            
            //Berechne Abstand zum Spieler
            Vector3 difference = player.transform.position - transform.position;
            //Berechnet den Abstand, jedoch quadriert da laut Unity-Doku effizienter
            float sqrDistance = difference.sqrMagnitude;

            //Wenn Wächter in Reichweite ist (Reichweite quadriert, da Abstand es auch ist)
            if (sqrDistance < range * range){

                //Raycast zum Player um herauszufinden ob Sichtkontakt besteht (falls hinter Wand oder Object)
                RaycastHit hit;

                // Auf der Höhe 3.5f, damit der Wächter über andere Objekte hinweg sehen kann
                if (Physics.Raycast(transform.position + new Vector3(0,3.5f,0), difference, out hit, range)){
                    Debug.Log("Sees something");
                    //Wenn Wächter Sichtkontakt hat
                    if(hit.transform.gameObject == player){
                        chase = true;
                        agent.speed = 11f;

                        //Zurücksetzten für Ende der Verfolgung
                        hasDest = false;
                        timer = 0;

                        Debug.Log("OHHHHHHHHH! NOW YOU FUCKED UP!");
                    }
                }                 
            }           
        }   
    }
}
