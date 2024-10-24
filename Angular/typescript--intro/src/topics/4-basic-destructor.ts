interface AudioPlayer {
    audioVolume: number;
    songDuration: number;
    song: string;
    details: Details;
}

interface Details {
    author: string;
    year: number;
}

const audioPlayer: AudioPlayer = {
    audioVolume: 90,
    songDuration: 36,
    song: "Misery Business",
    details: {
        author: "Hayley Williams",
        year: 2007
    }
};

console.log('song', audioPlayer.song)
console.log('duracion', audioPlayer.songDuration)
console.log('audioVolume', audioPlayer.audioVolume)

const { song: anotherSong, songDuration: duracion, audioVolume } = audioPlayer;
console.log({ anotherSong, duracion, audioVolume });

const song = 'New song';

// Desestructurar el autor -- autor está dentro de details -- mi manera
const { author: author } = audioPlayer.details 
console.log({author});

/*Manera 2
const {details} = audioPlayer;
const {author} = details;
console.log({author});*/

/*Manera 3
const { song: anotherSong, songDuration: duracion, audioVolume, details: {author} } = audioPlayer;
console.log({ anotherSong, duracion, audioVolume, author });*/

/*const team7: string [] = ["Naruto", "Sasuke", "Sakura"]
console.log("Personaje 3", team7[3] || 'No encontrado');*/

/*const sakura = team7[3] || 'No encontrado';
console.log('Personaje 3', sakura);*/

//const [naruto, sasuke, sakura]: string[] = ['Naruto', 'Sasuke', 'Sakura'];
const [, , sak = 'No encontrado']: string[] = ['Naruto', 'Sasuke', 'Sakura'];
console.log(sak);

export {};