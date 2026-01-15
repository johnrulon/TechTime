// Large interface: too many unrelated capabilities bundled together
interface ISmartHomeDevice {
    void playMusic();
    void setTemperature(int degreesF);
    void recordVideo();
    void turnOnLights();
}

// A device that is ONLY a thermostat is forced to implement music/camera/lights too
class ThermostatOnly implements ISmartHomeDevice {

    @Override
    public void setTemperature(int degreesF) {
        System.out.println("Thermostat set to " + degreesF + "°F");
    }

    @Override
    public void playMusic() {
        throw new UnsupportedOperationException("Music not supported");
    }

    @Override
    public void recordVideo() {
        throw new UnsupportedOperationException("Camera not supported");
    }

    @Override
    public void turnOnLights() {
        throw new UnsupportedOperationException("Lights not supported");
    }
}
