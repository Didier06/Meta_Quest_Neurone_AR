# Unity Meta Quest 3 Project: 3D Neuron in Augmented Reality

This project is an educational technical demonstration for the **Meta Quest 3**, leveraging **Passthrough (Mixed Reality)** and the **Meta XR Interaction SDK**.

The core objective is to visualize a highly detailed **3D animated Neuron** directly within the user's real-world environment and allow interactive learning by identifying its various anatomical parts using hand-tracking.

## Key Features

### 1. Mixed Reality (Passthrough)

- Utilizes the headset's AR/Passthrough camera to overlay the 3D neuron directly into the physical room.
- Transparent scene background ensures total immersion without breaking the user's connection to their surroundings.

### 2. Anatomical Interactions (Hands & Controllers)

The application allows users to physically reach out and interact with the neuron using Meta's Hand Tracking.
By touching specific areas of the model, floating 3D text panels (World Space UI) appear to identify the anatomical parts:

- **Dendrites**
- **Soma** (Cell Body)
- **Axon**
- **Myelin Sheath**
- *And more...*

### 3. Idle Animations

- The neuron features continuous ambient animations (e.g., cell pulsation, electrical impulses, or floating movement) managed through Unity's `Animator` and an assigned `Avatar` for complex rig interactions.

### 4. Remote Control (MQTT Connectivity)

The project includes a lightweight **MQTT Manager** (`MqttManager.cs`) allowing remote control of the neuron or other virtual objects via JSON messages.

- **Topic IN**: `FABLAB_21_22/Unity/metaquest/in` (Receives commands)
- **Topic OUT**: `FABLAB_21_22/Unity/metaquest/out` (Sends status)

#### Supported JSON Commands

You can dynamically update Position, Rotation, and Scale. The script identifies the target object via the `targetName` key.

```json
{
  "targetName": "Neurone",
  "position": { "x": 0.0, "y": 1.5, "z": 2.0 },
  "rotation": { "x": 0.0, "y": 45.0, "z": 0.0 },
  "scale": { "x": 1.5, "y": 1.5, "z": 1.5 }
}
```

Credentials for the MQTT connection are secure and **not committed** to Git. They must be stored locally in `Assets/Resources/secrets.json`.

## Technical Architecture

### Interaction Setup

To ensure precise and optimized interactions with the complex 3D neuron mesh:

- **Hitboxes**: Simplified invisible `Box Colliders` or `Sphere Colliders` (marked as *Is Trigger*) are placed strategically over the different anatomical parts of the 3D model.
- **Trigger Logic**: Custom scripts (e.g., `dendrites_interaction.cs`) detect when the player's hands (`Hand`, `Index`, or `Bone` tags) enter these trigger zones and trigger the display of the corresponding TextMeshPro floating UI.

### Frameworks & SDKs

This application strictly uses native Meta SDKs rather than AR Foundation for optimized performance and advanced hand-tracking physics:

1. **Meta XR Core SDK**: Camera rig, stereoscopic rendering, and passthrough.
2. **Meta XR Interaction SDK**: Detection of complex hand gestures, poking, and grabbing.

## How to Run

1. Open the project in **Unity 6** (or a Meta XR compatible version).
2. Ensure the build platform is set to **Android** (`File > Build Settings`).
3. Connect a **Meta Quest 3** headset via Link cable or build the `.apk` directly (`Build and Run`).
4. Once inside the headset, grant permission for Spatial Data (Passthrough) if prompted.
5. Walk up to the floating 3D neuron and use your bare hands to touch its different sections to learn more about its biology!
