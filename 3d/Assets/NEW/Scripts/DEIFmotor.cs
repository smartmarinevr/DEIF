using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DEIFmotor : MonoBehaviour
{
    public GameObject[] greenlight, Sunclights;

    public TMP_Text startDeif;

    public TMP_Text frequency, voltage, load, capacity, Load, frequency2, voltage2, load2, capacity2, Load2;

    public GameObject StartDG, Breacker1, Breacker1C;

    public GameObject l1, l2, l3/*, tele1*/;

    public TMP_Text m_Text;

    public GameObject AmmDEIFOn, AmmDEIFOff, AmmDEIFOn1, AmmDEIFOf1, AmmCraneOn, AmmCraneOf, closeafter;

    bool pressedStart = true, pressedBreacker = false, chichu = false, start = true;

    public Animator anim;
    public  bool FREQUENCYauto = false, VOLTAGEauto = false;
    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(Dummy());
        //as the command for the start crane is sent
        //also the written text to start the DEIF machine appears which says "as the load on running generator is 440V and the coming load is 100v whereas the generator capacity for load is 500V
        //so we need to start the new genrator with the DEIF module and the synchronisation will be done automatically.
        //the animation to start the new DEIF module arives (i.e. showing to press the start button on DEIF modulel)
        //
    }
    //for shipFly
    public void StartCheck()
    {
        StartCoroutine(Dummy());
    } 
    public void FrequencyAuto()
    {
        FREQUENCYauto = true;
    }
    public void FrequencyManual()
    {
        FREQUENCYauto = false;
    }
    public void VoltageAuto()
    {
        VOLTAGEauto = true;
    }
    public void VoltageManual()
    {
        VOLTAGEauto = false;
    }
    public void StartDEIF()
    {
        if (start)
        {

            StartCoroutine(StartMain());

            start = false;
            closeafter.SetActive(false);
        }

    }
    IEnumerator Dummy()
    {
        anim.SetBool("Hello", true);
        yield return new WaitForSeconds(10);
        m_Text.text = "Hello Sir, Welcome to the Engine Control Room.";
        FindObjectOfType<AudioManager>().Play("Dummy1");


        yield return new WaitForSeconds(3);
        m_Text.text = "I am the Electrical Engineer from DEIF.";
        FindObjectOfType<AudioManager>().Play("Dummy2");

        yield return new WaitForSeconds(3);
        anim.SetBool("Hello", false);
        m_Text.text = "You can look around the room and see there are many equipment's in the Room.";
        FindObjectOfType<AudioManager>().Play("Dummy3");

        yield return new WaitForSeconds(5);
        m_Text.text = "Allow me to show you the working of our power Management System in Auto/Manual mode.";
        FindObjectOfType<AudioManager>().Play("Dummy4");

        yield return new WaitForSeconds(5);
        m_Text.text = "Instruction on How to operate the DEIF module will also be given to you.";
        FindObjectOfType<AudioManager>().Play("Dummy5");

        yield return new WaitForSeconds(5);
        m_Text.text = "Press the auto button on both Frequency and Voltage to see the automatic tutorial.";
        FindObjectOfType<AudioManager>().Play("Audio24");



        yield return new WaitForSeconds(5);
        m_Text.text = "Press Manual on both Frequency and Voltage for manually operating the DEIF.";
        FindObjectOfType<AudioManager>().Play("Audio25");

        //change this
        yield return new WaitForSeconds(6);/*
        m_Text.text = "Press The start Button on your Left Hand Button to start the tutorial.";
        FindObjectOfType<AudioManager>().Play("Audio26");*/

        yield return new WaitForSeconds(5);

        StartCoroutine(StartMain());
    }

    private void FixedUpdate()
    {
        if (chichu)
        {

            Sunclights[37].SetActive(false);
            Sunclights[36].SetActive(false);
        }
        Debug.Log(FREQUENCYauto + "  " + VOLTAGEauto);
    }
    bool startcrane = false;
    IEnumerator StartMain()
    {
        anim.SetBool("Look", true);
        m_Text.text = "   ";
        startDeif.text = "An order to Start the Crane is arrived";
        FindObjectOfType<AudioManager>().Play("Audio1");
        yield return new WaitForSeconds(6);
        startDeif.text = "Press the button on starter panel to start the Crane.";

        l1.SetActive(true);
        //tele1.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Audio2");
        startcrane = true;

    }
    public void StartCrane()
    {
        if (startcrane)
        {
            anim.SetBool("Look", false);
            anim.SetBool("Start", true);
            closeafter.SetActive(false);
            startcrane = false;
            g = 0;
            chichu = false;
            l1.SetActive(false);
            //tele1.SetActive(false);
            startDeif.text = "Crane Start Initiated";
            FindObjectOfType<AudioManager>().Play("Audio3");


            StartCoroutine(PressedCraneBut());
        }
    }

    IEnumerator PressedCraneBut()
    {
        anim.SetBool("Start", false);
        anim.SetBool("Panel", true);
        yield return new WaitForSeconds(2);
        startDeif.text = "the Load Limit is reached";
        FindObjectOfType<AudioManager>().Play("Audio4");


        yield return new WaitForSeconds(5);
        startDeif.text = "start the new engine to cover the Load. ";
        FindObjectOfType<AudioManager>().Play("Audio5");

        yield return new WaitForSeconds(5);

        if (FREQUENCYauto && VOLTAGEauto)
        {

            StartCoroutine(GreenLightOn());


            StartDG.SetActive(true);
            frequency.text = frequency2.text = "frequency regulation";
            voltage.text = voltage2.text = "voltage:";
            load.text = load2.text = "load:";
            capacity.text = capacity2.text = "rated capacity:";
        }
        else
        {
            startDeif.text = "press the start button infront of you to start the DEIF module";
            FindObjectOfType<AudioManager>().Play("Audio6");

            l2.SetActive(true);
            pressedStart = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonPressStart()
    {
        //start the generator sound, audio
        //the start DG light is turned on
        if (!pressedStart)
        {
            l2.SetActive(false);
            StartCoroutine(GreenLightOn());

            anim.SetBool("Panel", false);
            anim.SetBool("Panel2", true);

            StartDG.SetActive(true);
            frequency.text = frequency2.text = "frequency regulation";
            voltage.text = voltage2.text = "voltage:";
            load.text = load2.text = "load:";
            capacity.text = capacity2.text = "rated capacity:";
            pressedStart = true;

        }

        //after 2 sec. the GreenLight1 will turned on
        //after 1 sec. the the green Light 2 will turned on

        //synchoronisation startsrotating the lights in 0.3 sec. gap.
        //and then after the rotating is completed twice it picks a no. b't 0-35
        //then the light turns on-off b't 0 to that no.of 0.5sec. gap
        //then picks a no. b/t 0-5 then roatting the light for 0-5 in 1 sec. gap for 7 sec. then the light all stops and Light0 remains on with MainLight trnd on too 
    }

    IEnumerator GreenLightOn()
    {
        yield return new WaitForSeconds(2);

        FindObjectOfType<AudioManager>().Play("SoundGenerator");
        startDeif.text = "NOW THE dief is starting as you can see the light is turned on.";
        FindObjectOfType<AudioManager>().Play("Audio7");
        greenlight[0].SetActive(true);
        yield return new WaitForSeconds(6);
        anim.SetBool("Panel2", false);


        startDeif.text = "NOW THE Synchronisation will take place. As you can see in the Synchroscope. ";
        FindObjectOfType<AudioManager>().Play("Audio8");
        greenlight[1].SetActive(true);
        StartCoroutine(SynchroLight3(1, 0));

        Debug.Log("check");
    }
    int g = 0;

    bool gg = false;

    IEnumerator SynchroLight3(int f, int i)
    {
        yield return new WaitForSeconds(0.3f);
        SuncLights(f, i);
    }
    public void SuncLights(int final, int initial)
    {
        Debug.Log(final);
        Sunclights[initial].SetActive(false);
        Sunclights[final].SetActive(true);
        if (chichu)
        {

            if (final == 35)
            {
                StartCoroutine(SynchroLight3(0, 35));
            }
            else if (final == 0)
            {
                StartCoroutine(SynchroLight3(1, 0));
            }
            else
                StartCoroutine(SynchroLight3(++final, ++initial));
        }
        else if (g < 1)
        {
            if (final == 35)
            {
                StartCoroutine(SynchroLight3(0, 35));
                if (g == 0)
                {

                    startDeif.text = "As you can see in the Synchroscope the DEIF is trying to adjust the required phase angle.";
                    FindObjectOfType<AudioManager>().Play("Audio9");
                }
                g++;
            }
            else if (final == 0)
            {
                StartCoroutine(SynchroLight3(1, 0));
            }
            else
                StartCoroutine(SynchroLight3(++final, ++initial));
        }
        else if (g > 0 & g < 3)
        {

            if (gg)
            {
                if (final == 0)
                {
                    gg = false;

                    StartCoroutine(SynchroLight3(1, 0));
                }
                else
                    StartCoroutine(SynchroLight3(--final, --initial));
            }
            else if (final == 15)
            {
                StartCoroutine(SynchroLight3(14, 15));
                gg = true;
                g++;
            }
            else if (final == 0)
            {
                StartCoroutine(SynchroLight3(1, 0));
            }
            else
                StartCoroutine(SynchroLight3(++final, ++initial));
        }
        else if (g > 2 & g < 5)
        {

            if (gg)
            {
                if (final == 0)
                {
                    gg = false;

                    StartCoroutine(SynchroLight3(1, 0));
                }
                else
                    StartCoroutine(SynchroLight3(--final, --initial));
            }
            else if (final == 5)
            {
                StartCoroutine(SynchroLight3(4, 5));
                gg = true;
                g++;
            }
            else if (final == 0)
            {
                StartCoroutine(SynchroLight3(1, 0));
            }
            else
                StartCoroutine(SynchroLight3(++final, ++initial));
        }
        else
        {
            Sunclights[0].SetActive(true);
            for (int i = 1; i < 35; i++)
            {
                Sunclights[i].SetActive(false);
            }

            Sunclights[37].SetActive(true);
            Sunclights[36].SetActive(true);

            if (FREQUENCYauto && VOLTAGEauto)
            {
                // soud that the "Now the Phase angle is Set. the Breaker will be closed to pass the current."


                startDeif.text = "Now the Phase angle is Set. the Breaker will be closed to pass the current.";
                FindObjectOfType<AudioManager>().Play("Audio23");


                Breacker1.SetActive(false);
                Breacker1C.SetActive(true);
                greenlight[2].SetActive(true);

                AmmDEIFOff.SetActive(false);
                AmmDEIFOf1.SetActive(false);

                AmmDEIFOn.SetActive(true);
                AmmDEIFOn1.SetActive(true);

                AmmCraneOn.SetActive(true);
                AmmCraneOf.SetActive(false);

                StartCoroutine(ChangesinScreen());
            }
            else
            {
                Breacker1.SetActive(true);
                //animation to press the breacker button
                pressedBreacker = true;

                startDeif.text = "Now the Phase angle is Set. Press the Breaker Close Button to make current flow";
                l3.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Audio10");

            }
        }

    }


    //when synchronous happens then the light on Breacker 1 is active and the breacker button is pressed.

    public void BreakerButtonPressed()
    {
        if (pressedBreacker)
        {
            l3.SetActive(false);
            Breacker1.SetActive(false);
            Breacker1C.SetActive(true);
            greenlight[2].SetActive(true);

            AmmDEIFOff.SetActive(false);
            AmmDEIFOf1.SetActive(false);

            AmmDEIFOn.SetActive(true);
            AmmDEIFOn1.SetActive(true);

            AmmCraneOn.SetActive(true);
            AmmCraneOf.SetActive(false);

            StartCoroutine(ChangesinScreen());
            pressedBreacker = false;
        }
    }

    IEnumerator ChangesinScreen()
    {
        yield return new WaitForSeconds(2);
        frequency.text = frequency2.text = "frequency regulation";
        voltage.text = voltage2.text = "voltage:440V";
        capacity.text = capacity2.text = "rated capacity:500kw";
        load.text = load2.text = "load:285KW";
        Load.text = Load2.text = "load:285KW";

        startDeif.text = "Now as you can see the generator is running and the load is distributed between two generators.";
        FindObjectOfType<AudioManager>().Play("Audio11");

        yield return new WaitForSeconds(13);

        startDeif.text = "For Stopping the crane, Press the button";

        FindObjectOfType<AudioManager>().Play("Audio12");
        ACS.SetActive(true);
        //tele1.SetActive(true);
        stopcrane = true;
    }
    public GameObject ACS, BO, SD;
    bool stopcrane = false;
    [SerializeField]
    GameObject carane1, crane2;
    public void StopCrane()
    {
        if (stopcrane)
        {
            stopcrane = false;
            ACS.SetActive(false);
            //tele1.SetActive(false);

            AmmCraneOn.SetActive(false);
            AmmCraneOf.SetActive(true);


            startDeif.text = "Crane Stop Initiated";
            FindObjectOfType<AudioManager>().Play("Audio13");

            load.text = load2.text = "load:235KW";
            Load.text = Load2.text = "load:235KW";

            crane2.SetActive(true);
            carane1.SetActive(true);

            AmmDEIFOn.SetActive(false);
            AmmDEIFOn1.SetActive(false);
            StartCoroutine(StopIntiate());
        }
    }
    bool chimpan = false, jalsk = false;
    IEnumerator StopIntiate()
    {

        yield return new WaitForSeconds(6);

        startDeif.text = "Now the Load on generator has been decreased.";

        FindObjectOfType<AudioManager>().Play("Audio14");


        yield return new WaitForSeconds(3);

        startDeif.text = "So we can shut one generator down.";

        FindObjectOfType<AudioManager>().Play("Audio15");


        yield return new WaitForSeconds(3);

        startDeif.text = "To stop the DEIF, we have to open the breaker first";

        FindObjectOfType<AudioManager>().Play("Audio16");


        yield return new WaitForSeconds(4);
        if (FREQUENCYauto && VOLTAGEauto)
        {

            BO.SetActive(false);
            Breacker1C.SetActive(false);



            AmmDEIFOff.SetActive(true);
            AmmDEIFOf1.SetActive(true);

            AmmDEIFOn.SetActive(false);
            AmmDEIFOn1.SetActive(false);

            crane2.SetActive(false);
            carane1.SetActive(false);


            greenlight[2].SetActive(false);
            startDeif.text = "Now AS the breaker is open.";

            frequency.text = frequency2.text = "frequency regulation";
            voltage.text = voltage2.text = "voltage:";
            load.text = load2.text = "load:";
            capacity.text = capacity2.text = "rated capacity:";
            Load.text = Load2.text = "load:470KW";

            FindObjectOfType<AudioManager>().Play("Audio18");
            StartCoroutine(Stop());

            chimpan = false;
            chichu = true;

            StartCoroutine(SynchroLight3(1, 0));
        }
        else
        {

            startDeif.text = "Press the Breaker open Button on DEIF.";

            FindObjectOfType<AudioManager>().Play("Audio17");

            BO.SetActive(true);
            chimpan = true;
        }
    }

    public void BreakerOpen()
    {
        if (chimpan)
        {

            BO.SetActive(false);
            Breacker1C.SetActive(false);



            AmmDEIFOff.SetActive(true);
            AmmDEIFOf1.SetActive(true);

            AmmDEIFOn.SetActive(false);
            AmmDEIFOn1.SetActive(false);

            crane2.SetActive(false);
            carane1.SetActive(false);


            greenlight[2].SetActive(false);
            startDeif.text = "Now AS the breaker is open.";

            frequency.text = frequency2.text = "frequency regulation";
            voltage.text = voltage2.text = "voltage:";
            load.text = load2.text = "load:";
            capacity.text = capacity2.text = "rated capacity:";
            Load.text = Load2.text = "load:470KW";

            FindObjectOfType<AudioManager>().Play("Audio18");
            StartCoroutine(Stop());

            chimpan = false;
            chichu = true;

            StartCoroutine(SynchroLight3(1, 0));

        }

    }
    IEnumerator Stop()
    {

        yield return new WaitForSeconds(3);

        startDeif.text = "The Load is shifted to the running DEIF";

        FindObjectOfType<AudioManager>().Play("Audio19");


        greenlight[1].SetActive(false);
        yield return new WaitForSeconds(10);
        if (FREQUENCYauto && VOLTAGEauto)
        {

            greenlight[0].SetActive(false);

            FindObjectOfType<AudioManager>().Stop("SoundGenerator");

            SD.SetActive(false);
            startDeif.text = "Now the DEIF is stopped.";
            StartDG.SetActive(false);

            StopAllCoroutines();

            for (int i = 0; i < 36; i++)
            {
                Sunclights[i].SetActive(false);
            }
            frequency.text = frequency2.text = " ";
            voltage.text = voltage2.text = " ";
            load.text = load2.text = " ";
            capacity.text = capacity2.text = " ";

            FindObjectOfType<AudioManager>().Play("Audio21");
            StartCoroutine(Stoppeed());
            jalsk = false;
        }
        else
        {

            startDeif.text = "Now to stop the DEIF. Press the highlighted button";

            FindObjectOfType<AudioManager>().Play("Audio20");

            SD.SetActive(true);
            jalsk = true;
        }
    }


    public void StopDEIF()
    {
        if (jalsk)
        {
            greenlight[0].SetActive(false);

            FindObjectOfType<AudioManager>().Stop("SoundGenerator");

            SD.SetActive(false);
            startDeif.text = "Now the DEIF is stopped.";
            StartDG.SetActive(false);

            StopAllCoroutines();

            for (int i = 0; i < 36; i++)
            {
                Sunclights[i].SetActive(false);
            }
            frequency.text = frequency2.text = " ";
            voltage.text = voltage2.text = " ";
            load.text = load2.text = " ";
            capacity.text = capacity2.text = " ";

            FindObjectOfType<AudioManager>().Play("Audio21");
            StartCoroutine(Stoppeed());
            jalsk = false;

        }
    }
    IEnumerator Stoppeed()
    {

        yield return new WaitForSeconds(3);

        startDeif.text = " Tutorial of DEIF ends Here.";

        FindObjectOfType<AudioManager>().Play("Audio22");

        yield return new WaitForSeconds(8);
        closeafter.SetActive(true);
        startDeif.text = "Press the button on starter panel to start the Crane.";
        l1.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Audio2");

        startcrane = true;
    }
    
    /*
    public GameObject pauseText, pauseButton, resumeText, resumeButton;
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseText.SetActive(false);
        resumeText.SetActive(true);
        resumeButton.SetActive(true);
    }
    public void resume()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseText.SetActive(true);
        resumeText.SetActive(false);
        resumeButton.SetActive(false);
    }*/

}
