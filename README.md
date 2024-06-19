# Leo-s-Game

Leo-s-Games é um jogo de sobrevivência em primeira pessoa ambientado em um mundo pós-apocalíptico, onde um vazamento de substâncias químicas causou a mutação de humanos em mortos-vivos. O jogo é uma experiência intensa de fuga e sobrevivência, com um ciclo dinâmico de dia e noite, trovoadas assustadoras e uma atmosfera opressiva. O jogador está confinado dentro de um carro em constante movimento, tentando escapar de hordas de zumbis enquanto lida com desafios mecânicos e limitações de recursos.

Menu principal: Menu
![image](https://github.com/LeoBoni/Leo-s-Games/assets/89111824/0ee57af0-93c6-462e-9cfa-0f4ff81688dc)

Carro: Carro
![image](https://github.com/LeoBoni/Leo-s-Games/assets/89111824/6a2ce504-1751-4c49-a309-6dd236494824)

Dia: Print1
![image](https://github.com/LeoBoni/Leo-s-Games/assets/89111824/d5948b93-3ff4-4879-b292-90ad46ad348f)

Noite: Print2
![image](https://github.com/LeoBoni/Leo-s-Games/assets/89111824/1c09ba46-50cf-46f6-80a4-3ba96ae51db6)

Perspectiva:

Primeira pessoa, dentro do carro.
Objetivo:

Sobreviver enquanto foge dos zumbis.
O jogo possui um ciclo completo de dia e noite, afetando a visibilidade.
Tempestades e trovoadas ocorrem aleatoriamente, criando momentos de alta tensão.
Encontros aleatórios com zumbis.
Ambiente e Atmosfera:

Ambientes detalhados e atmosféricos com uma estética sombria e pós-apocalíptica.
Uso de iluminação dinâmica para realçar o terror noturno e a opressão das tempestades.
Áudio:

Som ambiente realista que inclui o barulho dos trovões, e os gritos distantes dos zumbis.
Trilha sonora tensa que aumenta a imersão e a sensação de perigo iminente.
Protagonista:

O jogador, um cientista tentando sobreviver ao desastre.
Tutorial como jogar: Para jogar Leo´s Game é muito simples, as unicas funcionalidades são mover o carro para frente para tras e fazer curvas, sendo possivel utilizar A(Esquerda) S(Ré) D(Direita) W(Frente) ou as setas indicativas, o único objetivo é ficar longe dos zumbis

Funcionalidades: As funcionalidades desenvolvidas foram a criação de dia/noite, onde possui um intervalo de 60 segundo entre os dois e a criação de trovões, na qual é disparado em momentos aleatórios para deixar o jogo mais tenso.

Código Dia/Noite:

using UnityEngine; public class DayNightCycle : MonoBehaviour { public Light directionalLight; public float dayDuration = 60f; // Duration of one day in seconds

private float timeOfDay = 0f;

void Update()
{
    // Increment time of day
    timeOfDay += Time.deltaTime / dayDuration;

    // Calculate the angle of the sun
    float sunAngle = timeOfDay * 360f;

    // Rotate the directional light to simulate the sun
    directionalLight.transform.rotation = Quaternion.Euler(new Vector3(sunAngle - 90f, 170f, 0));

    // Reset time of day if it exceeds 1 (i.e., one full cycle)
    if (timeOfDay >= 1f)
    {
        timeOfDay = 0f;
    }
}
}

Código Trovão: using System.Collections; using UnityEngine;

public class LightningManager : MonoBehaviour { public Light lightningLight; public AudioSource thunderSound; public float minTimeBetweenLightning = 10f; public float maxTimeBetweenLightning = 30f; public float lightningDuration = 0.2f; // Duration of the lightning flash

private void Start()
{
    if (lightningLight == null)
    {
        Debug.LogError("Lightning light not assigned.");
        return;
    }

    if (thunderSound == null)
    {
        Debug.LogError("Thunder sound not assigned.");
        return;
    }

    lightningLight.enabled = false;
    StartCoroutine(ControlLightning());
}

private IEnumerator ControlLightning()
{
    while (true)
    {
        // Wait for a random time before starting the next lightning
        float timeToWait = Random.Range(minTimeBetweenLightning, maxTimeBetweenLightning);
        yield return new WaitForSeconds(timeToWait);

        // Flash the lightning
        lightningLight.enabled = true;
        yield return new WaitForSeconds(lightningDuration);
        lightningLight.enabled = false;

        // Play thunder sound with a delay to simulate distance
        float thunderDelay = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(thunderDelay);
        thunderSound.Play();
    }
}
}

Video: https://youtu.be/xyAdurkDdBo
