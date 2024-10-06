#define OPTO_1_PIN 3
#define OPTO_2_PIN 2
#define RELAY_1_PIN 51
#define RELAY_2_PIN 53
#define GO_BUTTON_PIN 43
#define GO_LED_PIN 8
#define A1_LED_PIN 10
#define A2_LED_PIN 11
#define A3_LED_PIN 12
#define A4_LED_PIN 13
#define B1_LED_PIN 9
#define B2_LED_PIN 7
#define B3_LED_PIN 6
#define B4_LED_PIN 45
#define TRACK_1_LED_PIN 5
#define TRACK_2_LED_PIN 4
#define A1_BUTTON_PIN 29
#define B1_BUTTON_PIN 31
#define B2_BUTTON_PIN 33
#define B3_BUTTON_PIN 35
#define A2_BUTTON_PIN 27
#define A3_BUTTON_PIN 25
#define A4_BUTTON_PIN 23
#define B4_BUTTON_PIN 47


#define TRACK_1_BUTTON_PIN 37
#define TRACK_2_BUTTON_PIN 39
#define BUZZER_PIN 52

#define TIMEOUT_SECONDS 10


// TODO
// Go button to relays
// Go button LED
// Radio Button code
// Combo Button code
// PWM LEDS

volatile bool timingflag = false;
volatile bool recordtimeflag = false;
bool newtimeflag = false;
unsigned long starttime, endtime, pulsewidth;
bool raceinprogress = false;
bool golatch = false;
unsigned long racestart = 0, raceend1 = 0, raceend2 = 0;
bool relay_1_on = false, relay_2_on = false;

class LatchingButton {
  public:
    LatchingButton(int p, int lp) {
      pin = p;
      ledPin = lp;
      state = false;
      buttonstate = false;
      buttonpressed = false;
    }
    int pin;
    int ledPin;
    bool state;
    bool buttonstate;
    bool buttonpressed;
    void updateButton() {
      buttonstate = digitalRead(pin) == LOW;
      if (!buttonpressed && buttonstate) {
        buttonpressed = true;
        state = !state;
      } else if (buttonpressed && !buttonstate) {
        buttonpressed = false;
      }
      digitalWrite(ledPin, state ? HIGH : LOW);
    }
};

LatchingButton BuzzerButton(B4_BUTTON_PIN, B4_LED_PIN);
LatchingButton Track1Button(TRACK_1_BUTTON_PIN, TRACK_1_LED_PIN);
LatchingButton Track2Button(TRACK_2_BUTTON_PIN, TRACK_2_LED_PIN);
LatchingButton ComboButton(B3_BUTTON_PIN, B3_LED_PIN);

enum Material {
  Plastic = 0,
  Wood = 1,
  Felt = 2,
  Rubber = 3
};
const int materialLEDs[4] = {A1_LED_PIN, A2_LED_PIN, A3_LED_PIN, A4_LED_PIN};
const int materialButtons[4] = {A1_BUTTON_PIN, A2_BUTTON_PIN, A3_BUTTON_PIN, A4_BUTTON_PIN};

enum Width {
  Narrow = 0,
  Wide = 1
};
const int widthLEDs[4] = {B1_LED_PIN, B2_LED_PIN};
const int widthButtons[4] = {B1_BUTTON_PIN, B2_BUTTON_PIN};

class TrackState {
  public:
    TrackState(int tracknum) {
      tracknumber = tracknum;
      // defaults
      material = Plastic;
      width = Wide;
      combo = true;
      enabled = false;
    }
    Material material;
    Width width;
    bool combo;
    bool enabled;
    int tracknumber;
    void ShowState();
    void UpdateState();
    void CopyFromState(TrackState& t);
    void SendState();
};

const int trackLEDs[4] = {TRACK_1_LED_PIN, TRACK_2_LED_PIN};
const int trackButtons[4] = {TRACK_1_BUTTON_PIN, TRACK_2_BUTTON_PIN};

void TrackState::ShowState() {
  for (int i = 0; i < 4; i++) {
    // turn all the LEDs off except the selected one
    if (material == i && !combo) digitalWrite(materialLEDs[i], HIGH);
    else digitalWrite(materialLEDs[i], LOW);
    if (i < 2) {
      if (width == i && !combo) digitalWrite(widthLEDs[i], HIGH);
      else digitalWrite(widthLEDs[i], LOW);
    }
  }
  ComboButton.state = combo;
  ComboButton.updateButton();
}

void TrackState::UpdateState() {
  if (enabled) {
    for (int i = 0; i < 4; i++) {
      if (digitalRead(materialButtons[i]) == LOW) { // buttons are active low
        material = (Material)i;
        ComboButton.state = false;
      }
      if (i < 2 && digitalRead(widthButtons[i]) == LOW) {
        width = (Width)i;
        ComboButton.state = false;
      }
    }
    combo = ComboButton.state;
    ShowState();
  }
}

void TrackState::CopyFromState(TrackState& t) {
  material = t.material;
  width = t.width;
  combo = t.combo;
}

void TrackState::SendState() {
  Serial.print("T"); Serial.print(tracknumber);
  Serial.print(",M"); Serial.print((int)material);
  Serial.print(",W"); Serial.print((int)width);
  Serial.print(",C"); Serial.print(combo ? 1 : 0);
}

void ISR_OPTO_1() {
  if (digitalRead(OPTO_1_PIN) == HIGH) {
    if (!timingflag && !recordtimeflag) {
      recordtimeflag = true;
    }
  } else {
    if (timingflag && !recordtimeflag) {
      recordtimeflag = true;
    }
  }
}

TrackState track1state(1);
TrackState track2state(2);

void setup() {
  // put your setup code here, to run once:
  pinMode(OPTO_1_PIN, INPUT);
  pinMode(RELAY_1_PIN, OUTPUT);
  pinMode(RELAY_2_PIN, OUTPUT);
  pinMode(GO_LED_PIN, OUTPUT);
  pinMode(BUZZER_PIN, OUTPUT);
  pinMode(TRACK_1_LED_PIN, OUTPUT);
  pinMode(TRACK_2_LED_PIN, OUTPUT);
  pinMode(A1_LED_PIN, OUTPUT);
  pinMode(A2_LED_PIN, OUTPUT);
  pinMode(A3_LED_PIN, OUTPUT);
  pinMode(A4_LED_PIN, OUTPUT);
  pinMode(B1_LED_PIN, OUTPUT);
  pinMode(B2_LED_PIN, OUTPUT);
  pinMode(B3_LED_PIN, OUTPUT);
  pinMode(B4_LED_PIN, OUTPUT);
  pinMode(GO_BUTTON_PIN, INPUT_PULLUP);
  pinMode(A1_BUTTON_PIN, INPUT_PULLUP);
  pinMode(A2_BUTTON_PIN, INPUT_PULLUP);
  pinMode(A3_BUTTON_PIN, INPUT_PULLUP);
  pinMode(A4_BUTTON_PIN, INPUT_PULLUP);
  pinMode(B1_BUTTON_PIN, INPUT_PULLUP);
  pinMode(B2_BUTTON_PIN, INPUT_PULLUP);
  pinMode(B3_BUTTON_PIN, INPUT_PULLUP);
  pinMode(B4_BUTTON_PIN, INPUT_PULLUP);
  pinMode(TRACK_1_BUTTON_PIN, INPUT_PULLUP);
  pinMode(TRACK_2_BUTTON_PIN, INPUT_PULLUP);
  //  attachInterrupt(digitalPinToInterrupt(OPTO_1_PIN),ISR_OPTO_1,CHANGE);
  Serial.begin(115200);
//  while (!Serial);
  ComboButton.state = true;
  Track2Button.state = false;
  BuzzerButton.state = true;
  track2state.enabled = true;
}

unsigned long timestamp = 0;
unsigned long lastupdate = 0;
int refreshinterval = 500;
bool redLEDon = false;
bool track1enabled = true;
bool track2enabled = true;

void LEDPWM();
int pwm = 0;
int pwmup = 0;
int pwmdown = 0;

void loop() {
  // put your main code here, to run repeatedly:
  timestamp = millis();
  //  if (recordtimeflag) {
  //    if (!timingflag) {
  //      starttime = timestamp;
  //      timingflag = true;
  //    } else {
  //      endtime = timestamp;
  //      pulsewidth = endtime - starttime;
  //      timingflag = false;
  //      newtimeflag = true;
  //    }
  //    recordtimeflag = false;
  //  }

  // couple GO button to relay pins if tracks are enabled
  if (digitalRead(GO_BUTTON_PIN) == HIGH) { // because although switches are active-low, this is wired to the NC terminals on the GO button
    if (!raceinprogress && !golatch) {
      relay_1_on = true;
      relay_2_on = true;
      analogWrite(GO_LED_PIN, 255);
      racestart = millis();
      raceend1 = 0;
      raceend2 = 0;
      raceinprogress = true;
      golatch = true;
    }
  } else {
//    digitalWrite(RELAY_1_PIN, HIGH);
//    digitalWrite(RELAY_2_PIN, HIGH);
    LEDPWM();
    raceinprogress = false;
    golatch = false;
    relay_1_on = false;
    relay_2_on = false;
  }
  // couple optosensors to Buzzer
  digitalWrite(BUZZER_PIN, (BuzzerButton.state && (digitalRead(OPTO_1_PIN) == HIGH || digitalRead(OPTO_2_PIN) == HIGH)) ? HIGH : LOW);
  // check if race should end
  bool timedout = (timestamp - racestart) > 1000UL * TIMEOUT_SECONDS;
  if (raceinprogress) {
    if ((digitalRead(OPTO_1_PIN) == HIGH && raceend1 == 0) || (timedout && raceend1 == 0)) {
      //if (!timedout) {
        raceend1 = millis();
        track1state.SendState();
        Serial.print(",");
        Serial.println(raceend1 - racestart);
      //}
      relay_1_on = false;
      if (((raceend1 > 0) && (raceend2 > 0)) || timedout) {
        raceinprogress = false;
        analogWrite(GO_LED_PIN, 0);
      }
    }
    if ((digitalRead(OPTO_2_PIN) == HIGH && raceend2 == 0) || (timedout && raceend2 == 0)) {
      //if (!timedout) {
        raceend2 = millis();
        track2state.SendState();
        Serial.print(",");
        Serial.println(raceend2 - racestart);
      //}
      relay_2_on = false;
      if (((raceend1 > 0) && (raceend2 > 0)) || timedout) {
        raceinprogress = false;
        analogWrite(GO_LED_PIN, 0);
      }
    }
  }
  // check latching buttons
  Track1Button.updateButton();
  Track2Button.updateButton();
  if ((!Track1Button.state && !Track2Button.state) || (Track1Button.state && Track2Button.state)) { // if neither enabled, enable the one not just pressed
    Track1Button.state = track2state.enabled;
    Track2Button.state = track1state.enabled;
    track1state.enabled = Track1Button.state;
    track2state.enabled = Track2Button.state;
    Track1Button.updateButton();
    Track2Button.updateButton();
  }
  // if both enabled, copy the state of the one just enabled to the other one
  //  if (Track1Button.state && Track2Button.state && (!track1state.enabled || !track2state.enabled)) {
  //    if (!track2state.enabled) {
  //      track1state.CopyFromState(track2state);
  //    }
  //    if (!track1state.enabled) {
  //      track2state.CopyFromState(track1state);
  //    }
  //  }
  if (Track1Button.state) { // if Track 1 is enabled, show the state
    track1state.enabled = Track1Button.state;
    if (track1state.enabled) track1state.ShowState();
  }
  if (Track2Button.state) { // if Track 2 is enabled, show the state
    track2state.enabled = Track2Button.state;
    if (track2state.enabled) track2state.ShowState();
  }

  track1state.UpdateState();
  track2state.UpdateState();

  BuzzerButton.updateButton();

  // update relays
  digitalWrite(RELAY_1_PIN, (relay_1_on) ? LOW : HIGH);
  digitalWrite(RELAY_2_PIN, (relay_2_on) ? LOW : HIGH);

  //  if (newtimeflag) {
  //    noInterrupts();
  //    Serial.print("Pulse detected at ");
  //    Serial.print((float)timestamp/1000.0);
  //    Serial.print(" s, pulse width ");
  //    Serial.print((float)pulsewidth/1000.0);
  //    Serial.println(" ms");
  //    newtimeflag = false;
  //    interrupts();
  //  }
  //  if (timestamp-lastupdate > refreshinterval) {
  //    lastupdate = timestamp;
  //    if (!redLEDon) { // toggle red LED
  //      digitalWrite(RED_LED_PIN,HIGH);
  //      redLEDon = true;
  //    } else {
  //      digitalWrite(RED_LED_PIN,LOW);
  //      redLEDon = false;
  //    }
  //  }
}

void LEDPWM() {
  if (timestamp - lastupdate > 25) {
    lastupdate = timestamp;
    if (pwmup < 256) pwmup += 8;
    else if (pwmdown < 256) pwmdown += 8;
    else {
      pwmup = 0;
      pwmdown = 0;
    }
    pwm = pwmup - pwmdown;
    if (pwm > 255) pwm = 255;
    analogWrite(GO_LED_PIN, pwm);
  }
}
