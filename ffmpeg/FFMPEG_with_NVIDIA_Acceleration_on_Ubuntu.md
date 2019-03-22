## Install the NVIDIA DISPLAY DRIVER

## NVENC SDK

0. Get the NVENC SDK from the NVIDIA developer's site.

    [https://developer.nvidia.com/nvidia-video-codec-sdk](https://developer.nvidia.com/nvidia-video-codec-sdk)

0. Copy the NVENC SDK to `~/Development`

    ```bash
    ~ $ mkdir Development
    ~ $ cd Develoment
    ~/Development $ wget http://developer.download.nvidia.com/compute/nvenc/v5.0/nvenc_5.0.1_sdk.zip
    ~/Development $ unzip nvenc_5.0.1_sdk.zip
    ```

0. Copy the NVENC headers to `/usr/local/include` to make it easer later
    ```bash
    ~/Development $ sudo cp nvenc_5.0.1_sdk/Samples/common/inc/*.h /usr/local/include/
    ```

## OPEN SOURCE LIBRARIES

0. Get x264

    ```bash
    ~/Development $ git clone git://git.videolan.org/x264.git
    ~/Development $ cd x264
    ```

0. Configure x264

    ```bash
    ~/Development/x264 $ ./configure \
    --disable-cli \
    --enable-static \
    --enable-shared \
    --enable-strip
    ```

0. Build x264

    ```bash
    ~/Development/x264 $ make -j 8
    ```

0. Install x264

    ```bash
    ~/Development/x264 $ sudo make install
    ~/Development/x264 $ sudo ldconfig
    ~/Development/x264 $ cd ..
    ```

## BUILD IT ALL TOGETHER

0. Get `ffmpeg`

    ```bash
    ~/Development $ git clone git://source.ffmpeg.org/ffmpeg.git
    ```

0. Download the NVIDIA acceleration

    ```bash
    ~/Development $ wget http://developer.download.nvidia.com/compute/redist/ffmpeg/1511-patch/ffmpeg_NVIDIA_gpu_acceleration.patch
    ~/Development $ cd ffmpeg
    ```

0. Apply the NVIDIA acceleration patch. Note that this patch was created against the git master commit `b83c849e8797fbb972ebd7f2919e0f085061f37f`

    ```bash
    ~/Development/ffmpeg $ git reset --hard b83c849e8797fbb972ebd7f2919e0f085061f37f
    ~/Development/ffmpeg $ git apply ../ffmpeg_NVIDIA_gpu_acceleration.patch
    ```

0. Edit the file `libx264.c` at `ffmpeg/libavcodec/`
    - replace `x264_bit_depth` with `X264_BIT_DEPTH`

0. Configure ffmpeg with NVENC, NVRESIZE and x264 support

    ```bash
    ~/Development/ffmpeg $ cd ..
    ~/Development/ $ mkdir ffmpeg_build
    ~/Development/ $ cd ffmpeg_build
    ~/Development/ffmpeg_build/ $ ../ffmpeg/configure --enable-nonfree \
    --enable-nvenc \
    --enable-nvresize \
    --extra-cflags=-I../cudautils \
    --extra-ldflags=-L../cudautils \
    --enable-gpl \
    --enable-libx264
    ```

0. Build ffmpeg

    ```bash
    ~/Development/ffmpeg_build $ make -j 8
    ```

0. Check that ffmpeg works. If NVENC and libx264 built properly you should get them in the list of encoders. We can filter the list down to h.264 encoders with `grep 264`

    ```bash
    ~/Development/ffmpeg_build $ ./ffmpeg -encoders | grep 264
    ffmpeg version N-76538-gb83c849e87 Copyright (c) 2000-2015 the FFmpeg developers built with gcc 8 (Ubuntu 8.2.0-7ubuntu1)
    configuration: --enable-nonfree --enable-nvenc --enable-nvresize --extra-cflags=-I../cudautils --extra-ldflags=-L../cudautils --enable-gpl --enable-libx264
    libavutil      55.  5.100 / 55.  5.100
    libavcodec     57. 15.100 / 57. 15.100
    libavformat    57. 14.100 / 57. 14.100
    libavdevice    57.  0.100 / 57.  0.100
    libavfilter     6. 15.100 /  6. 15.100
    libswscale      4.  0.100 /  4.  0.100
    libswresample   2.  0.101 /  2.  0.101
    libpostproc    54.  0.100 / 54.  0.100
    V..... libx264              libx264 H.264 / AVC / MPEG-4 AVC / MPEG-4 part 10 (codec h264)
    V..... libx264rgb           libx264 H.264 / AVC / MPEG-4 AVC / MPEG-4 part 10 RGB (codec h264)
    V..... nvenc                NVIDIA NVENC h264 encoder (codec h264)
    V..... nvenc_h264           NVIDIA NVENC h264 encoder (codec h264)
    ```

0. Chech that ffmpeg has the NVRESIZE video filter. We can filter the list down with `grep nvresize`

    ```bash
    ~/Development/ffmpeg_build $ ./ffmpeg -filters | grep nvresize
    ffmpeg version N-76538-gb83c849e87 Copyright (c) 2000-2015 the FFmpeg developers
    built with gcc 8 (Ubuntu 8.2.0-7ubuntu1)
    configuration: --enable-nonfree --enable-nvenc --enable-nvresize --extra-cflags=-I../cudautils --extra-ldflags=-L../cudautils --enable-gpl --enable-libx264
    libavutil      55.  5.100 / 55.  5.100
    libavcodec     57. 15.100 / 57. 15.100
    libavformat    57. 14.100 / 57. 14.100
    libavdevice    57.  0.100 / 57.  0.100
    libavfilter     6. 15.100 /  6. 15.100
    libswscale      4.  0.100 /  4.  0.100
    libswresample   2.  0.101 /  2.  0.101
    libpostproc    54.  0.100 / 54.  0.100
    ... nvresize         V->N       GPU accelerated video resizer.
    ```

0. Install ffmpeg

    ```bash
    ~/Development/ffmpeg_build $ sudo make install
    ~/Development/ffmpeg_build $ sudo ldconfig
    ```