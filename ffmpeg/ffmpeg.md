# FFMPEG

## Show file information

- `ffmpeg -i [input-file]`

## Converting

- `ffmpeg -i [input-file] [output-file]`

## Cutting

### Cut the first `x` seconds

- Automatically re-encoding based on the output's extension: `ffmpeg -i [input-file] -ss [x] [output-file]`

- Without re-encoding: `ffmpeg -i [input-file] -ss [x] -vcodec copy -acodec copy [output-file]`

timestamp format `hh:mm:ss.00`

### Cut from `start` to `end`

- `ffmpeg -i [input-file] -ss [start] -to [end] [output]`

## Extract audio stream without re-encodeing

- `ffmpeg -i [input-file] -vn -acodec copy [output-file]`

- Output file must have the appropriate extension for the audio stream.

## Embed subtitle into video

- `ffmpeg -i [input-video] -i [input-subtitle] -map 0 -map 1 -c copy [output-file]`

## Options

- `-vcodec copy` : copy video codec
- `-acodec copy` : copy audio codec
- `-vn` : no video

## create a video from an audio file and an image file

```sh
ffmpeg -loop 1 -i image.png -i audio.mp3 [-shortest] -acodec copy video.mkv
```
