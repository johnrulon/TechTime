// Lean interfaces: small, specific interfaces for each capability
interface IMusicPlayer {
    void playMusic();
}

interface IThermostat {
    void setTemperature(int degreesF);
}

interface ICamera {
    void recordVideo();
}

interface ILightSwitch {
    void turnOnLights();
}

// Now each class implements only what it needs
class ThermostatOnly implements IThermostat {
    @Override
    public void setTemperature(int degreesF) {
        System.out.println("Thermostat set to " + degreesF + "°F");
    }
}

// A more capable device can implement multiple small interfaces
class SmartHub implements IMusicPlayer, IThermostat, ICamera, ILightSwitch {

    @Override
    public void playMusic() {
        System.out.println("Playing music");
    }

    @Override
    public void setTemperature(int degreesF) {
        System.out.println("Thermostat set to " + degreesF + "°F");
    }

    @Override
    public void recordVideo() {
        System.out.println("Recording video");
    }

    @Override
    public void turnOnLights() {
        System.out.println("Lights on");
    }
}
